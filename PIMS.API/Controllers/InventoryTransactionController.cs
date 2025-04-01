using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [Authorize]
    [Route("api/inventory-transactions")]
    [ApiController]
    public class InventoryTransactionController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllInventoryTransactionsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetInventoryTransactionByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddInventoryTransactionCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}