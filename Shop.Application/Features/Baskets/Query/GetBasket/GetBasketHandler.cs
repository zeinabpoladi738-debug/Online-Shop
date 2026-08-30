using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Baskets.Queries.GetBasket;

public class GetBasketHandler
    : IRequestHandler<GetBasketQuery, GetBasketResponse>
{
    private readonly IBasketRepository _basketRepository;

    public GetBasketHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<GetBasketResponse> Handle(
        GetBasketQuery request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketRepository
            .GetBasketWithItemsAsync(request.UserId);

        if (basket == null)
        {
            throw new KeyNotFoundException(
                $"Basket for user {request.UserId} was not found.");
        }

        return new GetBasketResponse
        {
            ShoppingCartId = basket.Id,
            UserId = basket.UserId,

            Items = basket.Items.Select(item => new BasketItemResponse
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                ImageUrl = item.Product.ImageUrl

            }).ToList()
        };
    }
}