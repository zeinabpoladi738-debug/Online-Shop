using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler
    : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProductResponse> Handle(
        UpdateProductCommand request,
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

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.ImageUrl = request.ImageUrl;
        product.IsActive = request.IsActive;

        await _repository.UpdateAsync(product);

        await _repository.SaveChangeAsync();

        return new UpdateProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive
        };
    }
}