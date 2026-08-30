using MediatR;

namespace Shop.Application.Features.Baskets.Commands.AddItemToBasket;

public class AddItemToBasketCommand
    : IRequest<AddItemToBasketResponse>
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    
}