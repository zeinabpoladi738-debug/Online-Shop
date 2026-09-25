using MediatR;

namespace Shop.Application.Features.Order.Command.CreateOrder;

public class CreateOrderCommandRequest : IRequest<CreateOrderResponse>
{
    public int CartId { get; set; }
}