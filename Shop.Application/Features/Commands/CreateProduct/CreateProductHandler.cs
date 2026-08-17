using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            ImageUrl = request.ImageUrl,
            IsActive = true
        };

        await _repository.AddAsync(product);

        await _repository.SaveChangesAsync();

        return product.Id;
    }
}
