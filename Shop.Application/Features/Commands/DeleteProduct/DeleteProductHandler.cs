using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return false;

        _repository.Delete(product);

        await _repository.SaveChangesAsync();

        return true;
    }
}
