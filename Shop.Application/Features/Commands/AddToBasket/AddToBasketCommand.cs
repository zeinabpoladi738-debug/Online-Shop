using MediatR;

namespace Shop.Application.Features.Basket.Commands.AddToBasket;

public record AddToBasketCommand(
    int CartId,
    int ProductId,
    int Quantity
) : IRequest<AddToBasketResponse>;