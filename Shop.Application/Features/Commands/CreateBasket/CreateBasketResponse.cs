namespace Shop.Application.Features.Basket.Commands.CreateBasket;

public record CreateBasketResponse(
    int CartId,
    int UserId
);