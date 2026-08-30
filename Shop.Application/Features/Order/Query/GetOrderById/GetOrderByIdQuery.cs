using MediatR;
using Shop.Application.Features.Order.Query.GetOrderById;

namespace Shop.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<GetOrderByIdResponse>
{
    public int OrderId { get; set; }

    public int UserId { get; set; }
}