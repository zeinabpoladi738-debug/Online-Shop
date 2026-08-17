using MediatR;
using Shop.Application.Features.Products.Responses;

namespace Shop.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductResponse?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
