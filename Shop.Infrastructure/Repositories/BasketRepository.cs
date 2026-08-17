using Microsoft.EntityFrameworkCore;
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

    public async Task<ShoppingCartItem?> GetItemAsync(
        int cartId,
        int productId)
    {
        return await _context.ShoppingCartItems
            .FirstOrDefaultAsync(x =>
                x.ShoppingCartId == cartId &&
                x.ProductId == productId);
    }

    public async Task<ShoppingCart?> GetBasketWithItemsAsync(
        int cartId)
    {
        return await _context.ShoppingCarts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == cartId);
    }

    public async Task AddItemAsync(
        ShoppingCartItem item)
    {
        await _context.ShoppingCartItems.AddAsync(item);
    }

    public void UpdateItem(
        ShoppingCartItem item)
    {
        _context.ShoppingCartItems.Update(item);
    }

    public void DeleteItem(
        ShoppingCartItem item)
    {
        _context.ShoppingCartItems.Remove(item);
    }
}