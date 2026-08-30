using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetProducts;

public class GetProductsResponse
{
    public IReadOnlyList<Product> Products { get; set; } = new List<Product>();
}