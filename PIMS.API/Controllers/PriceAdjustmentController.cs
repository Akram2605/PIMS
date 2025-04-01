using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [Authorize]
    [Route("api/price-adjustments")]
    [ApiController]
    public class PriceAdjustmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceAdjustmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPriceAdjustmentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPriceAdjustmentByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPriceAdjustmentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}