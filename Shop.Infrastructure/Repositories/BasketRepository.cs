using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;


namespace Shop.Infrastructure.Repositories;

public class BasketRepository
    : BaseRepository<ShoppingCart>, IBasketRepository
{
    public BasketRepository(ShopDbContext context)
        : base(context)
    {
    }

    public async Task<ShoppingCart?> GetBasketWithItemsAsync(int userId)
    {
        return await _context.Set<ShoppingCart>()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddItemAsync(ShoppingCartItem item)
    {
        await _context.Set<ShoppingCartItem>().AddAsync(item);
    }

    public async Task<ShoppingCartItem?> GetItemAsync(
     int shoppingCartId,
     int productId)
    {
        return await _context.Set<ShoppingCartItem>()
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == shoppingCartId &&
                x.ProductId == productId);
    }

    public Task RemoveItemAsync(ShoppingCartItem item)
    {
        _context.Set<ShoppingCartItem>().Remove(item);

        return Task.CompletedTask;
    }

    public async Task ClearBasketAsync(int userId)
    {
        var basket = await _context.Set<ShoppingCart>()
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (basket == null)
            return;

        _context.Set<ShoppingCartItem>()
            .RemoveRange(basket.Items);

    }

    public Task UpdateItemAsync(ShoppingCartItem item)
    {
        _context.Set<ShoppingCartItem>().Update(item);

        return Task.CompletedTask;
    }
}