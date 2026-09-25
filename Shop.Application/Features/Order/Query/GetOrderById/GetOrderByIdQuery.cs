using MediatR;
using Shop.Application.Features.Order.Query.GetOrderById;

namespace Shop.Application.Features.Order.Query.GetOrderById;

public class GetOrderByIdQuery : IRequest<GetOrderByIdResponse>
{
    public int OrderId { get; set; }

    public int UserId { get; set; }
}