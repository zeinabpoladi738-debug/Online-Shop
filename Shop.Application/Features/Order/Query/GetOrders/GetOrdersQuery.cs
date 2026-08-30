using MediatR;
using Shop.Application.Features.Order.Query.GetOrders;

namespace Shop.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQuery : IRequest<GetOrdersResponse>
{
    public int UserId { get; set; }
}