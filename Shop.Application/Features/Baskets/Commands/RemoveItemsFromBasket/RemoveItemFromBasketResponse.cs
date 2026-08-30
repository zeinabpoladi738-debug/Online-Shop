namespace Shop.Application.Features.Baskets.Commands.RemoveItemFromBasket;

public class RemoveItemFromBasketResponse
{
    public int ShoppingCartId { get; set; }

    public int ProductId { get; set; }

    public string Message { get; set; } = string.Empty;
}