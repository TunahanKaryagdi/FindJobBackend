using FindJob.Application.Features.Skill.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private readonly IMediator _mediator;


        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSkillCommand createSkillCommand)
        {

            var result = await _mediator.Send(createSkillCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
