using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersHandler
    : IRequestHandler<GetOrdersQuery, GetOrdersResponse>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrdersResponse> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await _orderRepository
            .GetOrdersByUserIdAsync(request.UserId);

        return new GetOrdersResponse
        {
            Orders = orders.Select(order => new OrderListItemResponse
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString()
            }).ToList()
        };
    }
}