namespace Shop.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}