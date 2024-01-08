using FindJob.Application.Features.Jobs.Commands;
using FindJob.Application.Features.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly IMediator _mediator;


        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateJobCommand createJobCommand)
        {

            var result = await _mediator.Send(createJobCommand);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllJobsQuery getAllJobsQuery)
        {
            var result = await _mediator.Send(getAllJobsQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetJobByIdQuery getJobByIdQuery)
        {
            var result = await _mediator.Send(getJobByIdQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("User/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetJobsByUserIdQuery getJobsByUserIdQuery)
        {
            var result = await _mediator.Send(getJobsByUserIdQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteJobByIdCommand deleteJobByIdCommand)
        {
            var result = await _mediator.Send(deleteJobByIdCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateJobByIdCommand updateJobByIdCommand)
        {
            var result = await _mediator.Send(updateJobByIdCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
