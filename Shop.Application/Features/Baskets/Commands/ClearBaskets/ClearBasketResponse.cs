namespace Shop.Application.Features.Baskets.Commands.ClearBasket;

public class ClearBasketResponse
{
    public int ShoppingCartId { get; set; }

    public string Message { get; set; } = string.Empty;
}