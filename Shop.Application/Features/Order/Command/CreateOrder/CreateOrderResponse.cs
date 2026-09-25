namespace Shop.Application.Features.Order.Command.CreateOrder;

public class CreateOrderResponse
{
    public int OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = string.Empty;
}