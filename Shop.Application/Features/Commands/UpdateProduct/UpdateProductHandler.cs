using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler
    : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return false;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.ImageUrl = request.ImageUrl;

        _repository.Update(product);

        await _repository.SaveChangesAsync();

        return true;
    }
}
