using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [Authorize]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var category = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            var success = await mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await mediator.Send(new DeleteCategoryCommand { Id = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}