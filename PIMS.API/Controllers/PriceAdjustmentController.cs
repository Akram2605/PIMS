using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;
using PIMS.Domain.Entities;

namespace PIMS.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/price-adjustments")]
    [ApiVersion("1.0")]
    [Authorize]
    
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddPriceAdjustmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Created(string.Empty, result.Id);
        }
    }
}