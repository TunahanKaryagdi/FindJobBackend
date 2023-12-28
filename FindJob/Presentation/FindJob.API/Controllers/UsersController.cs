using FindJob.Application.Features.Users.Commands;
using FindJob.Application.Features.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {

            var result = await _mediator.Send(createUserCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInCommand signInCommand)
        {
            var result = await _mediator.Send(signInCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("googlesignin")]
        public async Task<IActionResult> SignInWithGoogle(SignInWithGoogleCommand signInWithGoogleCommand)
        {
            SignInWithGoogleDto signInWithGoogleDto = await _mediator.Send(signInWithGoogleCommand);
            return Ok(signInWithGoogleDto);
        }

    }
}
