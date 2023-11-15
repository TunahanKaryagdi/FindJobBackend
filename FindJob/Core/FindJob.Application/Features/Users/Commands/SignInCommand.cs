using FindJob.Application.Abstractions.Token;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Users.Commands
{
    public class SignInCommand : IRequest<SignInDto> 
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInDto>
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

            public async Task<SignInDto> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
               
                AppUser user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new  Exception("cannot find user");
                }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    SuccessSignInDto successSignInDto = new SuccessSignInDto();
                    successSignInDto.Success = true;
                    successSignInDto.Message = "succesfully sign in";
                    successSignInDto.Token = _tokenHelper.CreateAccessToken();
                    return successSignInDto;
                }
                ErrorSignInDto errorSignInDto = new ErrorSignInDto();
                errorSignInDto.Success = false;
                errorSignInDto.Message = "sign in failed";
                return errorSignInDto;
            }
        }
    }
}
