using MediatR;
using Shop.Application.Features.Baskets.Commands.RemoveItemFromBasket;

namespace Shop.Application.Features.Baskets.Commands.RemoveItemFromBasket;

public class RemoveItemFromBasketCommand
    : IRequest<RemoveItemFromBasketResponse>
{
    public int UserId { get; set; }

    public int ProductId { get; set; }
}