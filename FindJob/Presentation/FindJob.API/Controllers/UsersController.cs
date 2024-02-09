using FindJob.Application.Features.CompanyStaff.Queries;
using FindJob.Application.Features.Users.Commands;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.Users.Queries;
using FindJob.Application.Features.WorkingUser.Commands;
using FindJob.Application.Features.WorkingUser.Queries;
using FindJob.Application.Utilities.Enums;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly RoleManager<AppRole> _roleManager;

        public UsersController(IMediator mediator, RoleManager<AppRole> roleManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
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

        [HttpGet]
        [Authorize(Roles = "EMPLOYER")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery getAllUsersQuery)
        {

            var result = await _mediator.Send(getAllUsersQuery);
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

        [HttpGet("{UserId}/Companies")]
        public async Task<IActionResult> GetUsersByCompanyId([FromRoute] GetCompaniesByUserIdQuery getCompaniesByUserIdQuery)
        {
            var result = await _mediator.Send(getCompaniesByUserIdQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Companies")]
        public async Task<IActionResult> CreateWorkingUser(CreateCompanyStaffCommand createWorkingUserCommand)
        {

            var result = await _mediator.Send(createWorkingUserCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserByIdCommand deleteUserByIdCommand)
        {
            var result = await _mediator.Send(deleteUserByIdCommand);
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

        [HttpPost]
        [Route("create-roles")]
        public async Task<IActionResult> CreateRoles()
        {
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(AuthRole.USER.ToString());
            bool isEmployerRoleExists = await _roleManager.RoleExistsAsync(AuthRole.EMPLOYER.ToString());
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(AuthRole.ADMIN.ToString());

            if (isUserRoleExists && isEmployerRoleExists && isAdminRoleExists)
            {
                return Ok("roles already exists");
            }

            await _roleManager.CreateAsync(new AppRole { Name = AuthRole.USER.ToString()});
            await _roleManager.CreateAsync(new AppRole { Name = AuthRole.EMPLOYER.ToString() });
            await _roleManager.CreateAsync(new AppRole { Name = AuthRole.ADMIN.ToString() });
            return Ok("successfully created");

        }
    }
}
