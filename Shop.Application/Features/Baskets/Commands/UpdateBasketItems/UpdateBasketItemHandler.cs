using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Baskets.Commands.UpdateBasketItem;

public class UpdateBasketItemHandler
    : IRequestHandler<UpdateBasketItemCommand, UpdateBasketItemResponse>
{
    private readonly IBasketRepository _basketRepository;

    public UpdateBasketItemHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<UpdateBasketItemResponse> Handle(
        UpdateBasketItemCommand request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketRepository
            .GetBasketWithItemsAsync(request.UserId);

        if (basket == null)
        {
            throw new KeyNotFoundException("Basket not found.");
        }

        var item = await _basketRepository.GetItemAsync(
            basket.Id,
            request.ProductId);

        if (item == null)
        {
            throw new KeyNotFoundException(
                "Product does not exist in basket.");
        }

        if (request.Quantity <= 0)
        {
            throw new ArgumentException(
                "Quantity must be greater than zero.");
        }

        item.Quantity = request.Quantity;

        await _basketRepository.UpdateItemAsync(item);

        await _basketRepository.SaveChangeAsync();

        return new UpdateBasketItemResponse
        {
            ShoppingCartItemId = item.Id,
            ProductId = item.ProductId,
            ProductName = item.Product.Name,
            Quantity = item.Quantity,
            Price = item.Price,
            ImageUrl = item.Product.ImageUrl
        };
    }
}