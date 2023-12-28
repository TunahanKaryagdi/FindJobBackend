using FindJob.Application.Features.Applications.Commands;
using FindJob.Application.Features.Applications.Queries;
using FindJob.Application.Features.Jobs.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllApplicationsQuery getAllApplicationsQuery)
        {
            var result = await _mediator.Send(getAllApplicationsQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateApplicationCommand createApplicationCommand)
        {
            var result = await _mediator.Send(createApplicationCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
