using MediatR;
using Shop.Application.Features.Products.Responses;

namespace Shop.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<List<ProductResponse>>;
