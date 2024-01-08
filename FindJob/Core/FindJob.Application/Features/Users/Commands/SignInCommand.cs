using Core.Utilities.Results;
using FindJob.Application.Abstractions.Token;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Application.Features.Users.Commands
{
    public class SignInCommand : IRequest<IDataResult<string>>
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public class SignInCommandHandler : IRequestHandler<SignInCommand, IDataResult<string>>
        {

            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly ITokenHelper _tokenHelper;

            public SignInCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHelper tokenHelper)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _tokenHelper = tokenHelper;
            }

            public async Task<IDataResult<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
            {

                AppUser user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new Exception("cannot find user");
                }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    var token = _tokenHelper.CreateAccessToken(user.Id.ToString());
                    return new SuccessDataResult<string>(data: token.AccessToken, message: "successfully login");
                }

                return new ErrorDataResult<string>("failed");
            }
        }
    }
}
