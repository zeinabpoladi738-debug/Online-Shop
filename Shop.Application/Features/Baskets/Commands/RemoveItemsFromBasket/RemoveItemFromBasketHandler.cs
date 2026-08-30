using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Baskets.Commands.RemoveItemFromBasket;

public class RemoveItemFromBasketHandler
    : IRequestHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketResponse>
{
    private readonly IBasketRepository _basketRepository;

    public RemoveItemFromBasketHandler(
        IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<RemoveItemFromBasketResponse> Handle(
        RemoveItemFromBasketCommand request,
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

        await _basketRepository.RemoveItemAsync(item);

        await _basketRepository.SaveChangeAsync();

        return new RemoveItemFromBasketResponse
        {
            ShoppingCartId = basket.Id,
            ProductId = request.ProductId,
            Message = "Product removed from basket successfully."
        };
    }
}