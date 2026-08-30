namespace Shop.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersResponse
{
    public List<OrderListItemResponse> Orders { get; set; } = new();
}

public class OrderListItemResponse
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = string.Empty;
}