using MediatR;

namespace Shop.Application.Features.Baskets.Queries.GetBasket;

public class GetBasketQuery : IRequest<GetBasketResponse>
{
    public int UserId { get; set; }
}