using CleanArchG.Application.Commands;
using CleanArchG.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    // GET /api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await mediator.Send(new GetAllProductsQuery()));

    // GET /api/products/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    // POST /api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT /api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
    {
        var result = await mediator.Send(command with { Id = id });
        return result is null ? NotFound() : Ok(result);
    }

    // DELETE /api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await mediator.Send(new DeleteProductCommand(id));
        return success ? NoContent() : NotFound();
    }
}
