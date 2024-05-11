using FindJob.Application.Features.PreferredLocations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferredLocationsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PreferredLocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePreferredLocationCommand createPreferredLocationCommand)
        {

            var result = await _mediator.Send(createPreferredLocationCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
