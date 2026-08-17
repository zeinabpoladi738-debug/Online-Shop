using MediatR;
using Shop.Application.Features.Products.Responses;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler
    : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductResponse>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return products.Select(x => new ProductResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl
        }).ToList();
    }
}
