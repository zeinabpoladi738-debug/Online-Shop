using MediatR;

namespace Shop.Application.Features.Basket.Queries.GetBasket;

public record GetBasketQuery(
    int CartId
) : IRequest<GetBasketResponse>;