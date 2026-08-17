using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Basket.Commands.AddToBasket;
using Shop.Application.Features.Basket.Commands.CreateBasket;
using Shop.Application.Features.Basket.Queries.GetBasket;

namespace Shop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{cartId}")]
    public async Task<IActionResult> GetBasket(int cartId)
    {
        var result = await _mediator.Send(
            new GetBasketQuery(cartId));

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToBasket(
        [FromBody] AddToBasketCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBasket(
    [FromBody] CreateBasketCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}