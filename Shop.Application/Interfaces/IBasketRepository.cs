using Shop.Domain.Entities;

namespace Shop.Infrastructure.Repositories;

public interface IBasketRepository : IBaseRepository<ShoppingCart>
{
    Task<ShoppingCartItem?> GetItemAsync(
        int cartId,
        int productId);

    Task<ShoppingCart?> GetBasketWithItemsAsync(
        int cartId);

    Task AddItemAsync(
        ShoppingCartItem item);

    void UpdateItem(ShoppingCartItem item);

    void DeleteItem(ShoppingCartItem item);
}