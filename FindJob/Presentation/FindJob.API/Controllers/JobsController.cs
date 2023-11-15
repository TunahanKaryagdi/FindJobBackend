using FindJob.Application.Features.Jobs.Commands;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Jobs.Queries;
using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
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
            CreateJobDto createJobDto = await _mediator.Send(createJobCommand);
            return Ok(createJobDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllJobsQuery getAllJobsQuery)
        {
            GetAllJobsDto getAllJobsDto = await _mediator.Send(getAllJobsQuery);
            return Ok(getAllJobsDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetJobByIdQuery getJobByIdQuery)
        {
            JobDto getJobByIdDto = await _mediator.Send(getJobByIdQuery);
            return Ok(getJobByIdDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteJobByIdCommand deleteJobByIdCommand)
        {
            DeleteJobByIdDto deleteJobByIdDto = await _mediator.Send(deleteJobByIdCommand);
            return Ok(deleteJobByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateJobByIdCommand updateJobByIdCommand)
        {
            UpdateJobDto updateJobDto = await _mediator.Send(updateJobByIdCommand);
            return Ok(updateJobDto);
        }


    }
}
