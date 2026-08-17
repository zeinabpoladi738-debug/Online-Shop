using MediatR;

namespace Shop.Application.Features.Basket.Commands.CreateBasket;

public record CreateBasketCommand(
    int UserId
) : IRequest<CreateBasketResponse>;