using Shop.Domain.Entities;

namespace Shop.Application.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> GetOrderWithItemsAsync(int orderId);

    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}