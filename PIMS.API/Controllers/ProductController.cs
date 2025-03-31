using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Application.Queries.Products;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [Authorize]
    [Route("api/products")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var productId = await mediator.Send(command);
            return Created(string.Empty, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            var success = await mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await mediator.Send(new DeleteProductCommand { Id = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}