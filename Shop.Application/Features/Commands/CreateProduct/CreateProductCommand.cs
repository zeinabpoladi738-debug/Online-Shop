using MediatR;

namespace Shop.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}
