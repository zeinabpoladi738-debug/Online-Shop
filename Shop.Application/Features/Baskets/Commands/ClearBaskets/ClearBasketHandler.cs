using MediatR;
using Shop.Application.Features.Baskets.Commands.ClearBasket;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Baskets.Commands.ClearBasket;

public class ClearBasketHandler
    : IRequestHandler<ClearBasketCommand, ClearBasketResponse>
{
    private readonly IBasketRepository _basketRepository;

    public ClearBasketHandler(
        IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<ClearBasketResponse> Handle(
        ClearBasketCommand request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketRepository
            .GetBasketWithItemsAsync(request.UserId);

        if (basket == null)
        {
            throw new KeyNotFoundException("Basket not found.");
        }

        await _basketRepository.ClearBasketAsync(request.UserId);

        await _basketRepository.SaveChangeAsync();

        return new ClearBasketResponse
        {
            ShoppingCartId = basket.Id,
            Message = "Basket cleared successfully."
        };
    }
}