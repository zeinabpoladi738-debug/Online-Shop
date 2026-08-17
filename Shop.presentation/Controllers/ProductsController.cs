using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Features.Products.Commands.DeleteProduct;
using Shop.Application.Features.Products.Commands.UpdateProduct;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Products.Queries.GetProductById;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }

}
