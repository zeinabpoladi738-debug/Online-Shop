using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdResponse
{
    public Product? Product { get; set; }
}