using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories;

public class OrderRepository
    : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ShopDbContext context)
        : base(context)
    {
    }

    public async Task<Order?> GetOrderWithItemsAsync(int orderId)
    {
        return await _context.Set<Order>()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == orderId);
    }

    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return await _context.Set<Order>()
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.OrderDate)
            .ToListAsync();
    }
}