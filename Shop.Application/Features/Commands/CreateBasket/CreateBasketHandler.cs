using MediatR;
using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Features.Basket.Commands.CreateBasket;

public class CreateBasketHandler
    : IRequestHandler<CreateBasketCommand, CreateBasketResponse>
{
    private readonly IBasketRepository _basketRepository;

    public CreateBasketHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<CreateBasketResponse> Handle(
        CreateBasketCommand request,
        CancellationToken cancellationToken)
    {
        var basket = new ShoppingCart
        {
            UserId = request.UserId
        };

        await _basketRepository.AddAsync(basket);

        await _basketRepository.SaveChangesAsync();

        return new CreateBasketResponse(
            basket.Id,
            basket.UserId
        );
    }
}