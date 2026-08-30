using MediatR;

namespace Shop.Application.Features.Baskets.Commands.UpdateBasketItem;

public class UpdateBasketItemCommand : IRequest<UpdateBasketItemResponse>
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}