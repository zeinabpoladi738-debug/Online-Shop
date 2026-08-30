using MediatR;
using Shop.Application.Features.Baskets.Commands.ClearBasket;

namespace Shop.Application.Features.Baskets.Commands.ClearBasket;

public class ClearBasketCommand : IRequest<ClearBasketResponse>
{
    public int UserId { get; set; }
}