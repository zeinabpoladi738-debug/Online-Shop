using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Order.Command.CreateOrder;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommandRequest, CreateOrderResponse>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(
        IBasketRepository basketRepository,
        IOrderRepository orderRepository)
    {
        _basketRepository = basketRepository;
        _orderRepository = orderRepository;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetBasketWithItemsAsync(request.CartId);

        if (basket == null || !basket.Items.Any())
        {
            throw new KeyNotFoundException(
                "Basket is empty.");
        }

        var order = new Shop.Domain.Entities.Order
        {
            CartId = request.CartId,    
            UserId = null,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };

        foreach (var basketItem in basket.Items)
        {
            var orderItem = new OrderItem
            {
                ProductId = basketItem.ProductId,
                ProductName = basketItem.Product.Name,
                Price = basketItem.Product.Price,
                Quantity = basketItem.Quantity
            };

            order.Items.Add(orderItem);
        }

        order.TotalPrice = order.Items.Sum(
            x => x.Price * x.Quantity);

        await _orderRepository.AddAsync(order);

        await _orderRepository.SaveChangeAsync();

        return new CreateOrderResponse
        {
            OrderId = order.Id,
            TotalPrice = order.TotalPrice,
            Status = order.Status.ToString()
        };
    }
}