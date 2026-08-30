using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Baskets.Commands.AddItemToBasket;
using Shop.Application.Features.Baskets.Commands.ClearBasket;
using Shop.Application.Features.Baskets.Commands.RemoveItemFromBasket;
using Shop.Application.Features.Baskets.Commands.UpdateBasketItem;
using Shop.Application.Features.Baskets.Queries.GetBasket;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Basket/1
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetBasket(int userId)
    {
        var result = await _mediator.Send(
            new GetBasketQuery
            {
                UserId = userId
            });

        return Ok(result);
    }

    // POST: api/Basket
    [HttpPost]
    public async Task<IActionResult> AddItem(
        AddItemToBasketCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // PUT: api/Basket
    [HttpPut]
    public async Task<IActionResult> UpdateItem(
        UpdateBasketItemCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // DELETE: api/Basket/item
    [HttpDelete("item")]
    public async Task<IActionResult> RemoveItem(
        RemoveItemFromBasketCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // DELETE: api/Basket/1
    [HttpDelete("{userId}")]
    public async Task<IActionResult> ClearBasket(int userId)
    {
        var result = await _mediator.Send(
            new ClearBasketCommand
            {
                UserId = userId
            });

        return Ok(result);
    }
}