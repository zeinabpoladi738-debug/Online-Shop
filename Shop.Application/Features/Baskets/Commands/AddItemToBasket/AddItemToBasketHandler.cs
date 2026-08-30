using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Baskets.Commands.AddItemToBasket;

public class AddItemToBasketHandler
    : IRequestHandler<AddItemToBasketCommand, AddItemToBasketResponse>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IProductRepository _productRepository;

    public AddItemToBasketHandler(
        IBasketRepository basketRepository,
        IProductRepository productRepository)
    {
        _basketRepository = basketRepository;
        _productRepository = productRepository;
    }

    public async Task<AddItemToBasketResponse> Handle(
        AddItemToBasketCommand request,
        CancellationToken cancellationToken)
    {
        // 1. پیدا کردن محصول
        var product = await _productRepository.GetByIdAsync(
            request.ProductId,
            cancellationToken);

        if (product == null)
        {
            throw new KeyNotFoundException(
                $"Product with Id {request.ProductId} was not found.");
        }

        // 2. پیدا کردن سبد کاربر
        var basket = await _basketRepository
            .GetBasketWithItemsAsync(request.UserId);

        // 3. اگر سبد وجود نداشت، ایجادش کن
        if (basket == null)
        {
            basket = new ShoppingCart
            {
                UserId = request.UserId
            };

            await _basketRepository.AddAsync(basket);

            await _basketRepository.SaveChangeAsync();
        }

        // 4. بررسی اینکه محصول قبلاً در سبد هست یا نه
        var item = await _basketRepository.GetItemAsync(
            basket.Id,
            request.ProductId);

        // 5. اگر وجود داشت، تعداد را افزایش بده
        if (item != null)
        {
            item.Quantity += request.Quantity;
        }
        else
        {
            // 6. اگر وجود نداشت، آیتم جدید بساز
            item = new ShoppingCartItem
            {
                ShoppingCartId = basket.Id,
                ProductId = product.Id,
                Quantity = request.Quantity,
                Price = product.Price
            };

            await _basketRepository.AddItemAsync(item);
        }

        // 7. ذخیره
        await _basketRepository.SaveChangeAsync();

        // 8. Response
        return new AddItemToBasketResponse
        {
            ShoppingCartItemId = item.Id,
            ShoppingCartId = basket.Id,
            ProductId = product.Id,
            ProductName = product.Name,
            Quantity = item.Quantity,
            Price = product.Price,
            ImageUrl = product.ImageUrl
        };
    }
}