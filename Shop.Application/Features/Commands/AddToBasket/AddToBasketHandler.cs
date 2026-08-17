using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Features.Basket.Commands.AddToBasket;

public class AddToBasketHandler
    : IRequestHandler<AddToBasketCommand, AddToBasketResponse>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IProductRepository _productRepository;

    public AddToBasketHandler(
        IBasketRepository basketRepository,
        IProductRepository productRepository)
    {
        _basketRepository = basketRepository;
        _productRepository = productRepository;
    }

    public async Task<AddToBasketResponse> Handle(
        AddToBasketCommand request,
        CancellationToken cancellationToken)
    {
        // 1. پیدا کردن محصول
        var product = await _productRepository
            .GetByIdAsync(request.ProductId);

        if (product == null)
        {
            throw new Exception("محصول پیدا نشد.");
        }

        // 2. بررسی اینکه محصول قبلاً در سبد هست یا نه
        var item = await _basketRepository
            .GetItemAsync(request.CartId, request.ProductId);

        // 3. اگر محصول قبلاً در سبد وجود داشته باشد
        if (item != null)
        {
            item.Quantity += request.Quantity;

            _basketRepository.UpdateItem(item);
        }
        else
        {
            // 4. اگر محصول در سبد وجود نداشته باشد
            item = new ShoppingCartItem
            {
                ShoppingCartId = request.CartId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price

            };

             await _basketRepository.AddItemAsync(item);
        }

        // 5. ذخیره در دیتابیس
        await _basketRepository.SaveChangesAsync();

        // 6. برگرداندن Response
        return new AddToBasketResponse(
            request.CartId,
            product.Id,
            item.Quantity,
            product.Price
        );
    }
}