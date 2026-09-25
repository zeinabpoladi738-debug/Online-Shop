using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> GetOrderWithItemsAsync(int orderId);

    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}