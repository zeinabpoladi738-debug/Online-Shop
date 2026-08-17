namespace Shop.Application.Features.Basket.Commands.AddToBasket;

public record AddToBasketResponse(
    int CartId,
    int ProductId,
    int Quantity,
    decimal Price
);