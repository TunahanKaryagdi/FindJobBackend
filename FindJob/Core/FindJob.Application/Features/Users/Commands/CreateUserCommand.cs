using Core.Utilities.Results;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<IResult>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
        {

            private readonly UserManager<AppUser> _userManager;

            public CreateUserCommandHandler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    Id = Guid.NewGuid(),
                    NameSurname = request.NameSurname,
                    Email = request.Email,
                    UserName = request.Email,
                }, request.Password);

                if (result.Succeeded)
                {
                    return new SuccessResult("user created successfully");
                }
                return new ErrorResult("user does not create");

            }
        }


    }
}
