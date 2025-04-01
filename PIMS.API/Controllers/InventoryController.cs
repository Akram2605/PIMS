using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [Authorize]
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllInventoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetInventoryByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddInventoryCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInventoryCommand command)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await mediator.Send(new DeleteInventoryCommand { Id = id });
            if (!success) return NotFound();

            return NoContent();
        }
    }
}