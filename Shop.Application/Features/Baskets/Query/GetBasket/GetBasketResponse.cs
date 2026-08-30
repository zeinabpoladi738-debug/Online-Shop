namespace Shop.Application.Features.Baskets.Queries.GetBasket;

public class GetBasketResponse
{
    public int ShoppingCartId { get; set; }

    public int UserId { get; set; }

    public List<BasketItemResponse> Items { get; set; } = new();
}

public class BasketItemResponse
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}