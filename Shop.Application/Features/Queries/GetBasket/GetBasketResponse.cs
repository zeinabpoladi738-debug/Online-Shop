namespace Shop.Application.Features.Basket.Queries.GetBasket;

public record GetBasketResponse(
    int CartId,
    List<BasketItemResponse> Items
);

public record BasketItemResponse(
    int ProductId,
    int Quantity,
    decimal Price,
    string Name,
    string Description,
    string? ImageUrl
);