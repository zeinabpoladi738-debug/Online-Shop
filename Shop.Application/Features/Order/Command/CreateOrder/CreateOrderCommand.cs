using MediatR;
using Shop.Application.Features.Order.Command.CreateOrder;

namespace Shop.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderResponse>
{
    public int UserId { get; set; }
}