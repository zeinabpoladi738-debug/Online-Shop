using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Products.Queries.GetProducts;

public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProductsResponse> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return new GetProductsResponse
        {
            Products = products
        };
    }
}