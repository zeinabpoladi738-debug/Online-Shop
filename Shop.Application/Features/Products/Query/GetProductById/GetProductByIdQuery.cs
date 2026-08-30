using MediatR;

namespace Shop.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
{
    public int Id { get; set; }
}