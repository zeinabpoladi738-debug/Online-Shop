using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Interfaces;

public interface IBasketRepository : IBaseRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetBasketWithItemsAsync(int userId);

    Task AddItemAsync(ShoppingCartItem item);

    Task<ShoppingCartItem?> GetItemAsync(
        int shoppingCartId,
        int productId);

    Task UpdateItemAsync(ShoppingCartItem item);
    Task RemoveItemAsync(ShoppingCartItem item);
    Task ClearBasketAsync(int userId);
}