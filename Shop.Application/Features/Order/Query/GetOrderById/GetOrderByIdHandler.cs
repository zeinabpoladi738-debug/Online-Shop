using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler
    : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrderByIdResponse> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository
            .GetOrderWithItemsAsync(request.OrderId);

        if (order == null)
        {
            throw new KeyNotFoundException(
                "Order not found.");
        }

        if (order.UserId != request.UserId)
        {
            throw new UnauthorizedAccessException(
                "You are not allowed to access this order.");
        }

        return new GetOrderByIdResponse
        {
            OrderId = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Status = order.Status.ToString(),

            Items = order.Items.Select(item => new OrderItemResponse
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageUrl = item.Product.ImageUrl

            }).ToList()
        };
    }
}