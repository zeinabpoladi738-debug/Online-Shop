using MediatR;

namespace Shop.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<DeleteProductResponse>
{
    public int Id { get; set; }
}