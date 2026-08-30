using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler
    : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteProductResponse> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (product == null)
        {
            throw new KeyNotFoundException(
                $"Product with Id {request.Id} was not found.");
        }

        await _repository.DeleteAsync(product);

        await _repository.SaveChangeAsync();

        return new DeleteProductResponse
        {
            Id = product.Id,
            Success = true
        };
    }
}