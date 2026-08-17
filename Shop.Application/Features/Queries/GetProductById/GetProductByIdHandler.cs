using MediatR;
using Shop.Application.Features.Products.Responses;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return null;

        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl
        };
    }
}
