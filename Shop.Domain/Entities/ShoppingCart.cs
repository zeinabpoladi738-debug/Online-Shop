using Shop.Domain.Entities;

public class ShoppingCart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public ICollection<ShoppingCartItem> Items { get; set; }
        = new List<ShoppingCartItem>();

    public ICollection<Order> Orders { get; set; }
       = new List<Order>();
}
