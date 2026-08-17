using MediatR;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Features.Basket.Queries.GetBasket;

public class GetBasketHandler
    : IRequestHandler<GetBasketQuery, GetBasketResponse>
{
    private readonly IBasketRepository _basketRepository;

    public GetBasketHandler(
        IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<GetBasketResponse> Handle(
        GetBasketQuery request,
        CancellationToken cancellationToken)
    {
        var basket =
            await _basketRepository.GetBasketWithItemsAsync(
                request.CartId);

        if (basket == null)
        {
            throw new Exception("سبد خرید پیدا نشد.");
        }

        var items = basket.Items
            .Select(item => new BasketItemResponse(
                item.ProductId,
                item.Quantity,
                item.Price,
                item.Product.Name,
                item.Product.Description,
                item.Product.ImageUrl
            ))
            .ToList();

        return new GetBasketResponse(
            basket.Id,
            items
        );
    }
}