using FindJob.Application.Features.Users.Commands;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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



        [HttpPut]
        public async Task<IActionResult> Update([FromForm] string jsonBody, [FromForm] IFormFile? file)
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand();
            var body = JsonConvert.DeserializeObject<UpdateUserCommand>(jsonBody);
            updateUserCommand.Id = body.Id;
            updateUserCommand.NameSurname = body.NameSurname;
            updateUserCommand.Email = body.Email;
            updateUserCommand.File = file;
            var result = await _mediator.Send(updateUserCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserByIdQuery getUserByIdQuery)
        {
            var result = await _mediator.Send(getUserByIdQuery);
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
