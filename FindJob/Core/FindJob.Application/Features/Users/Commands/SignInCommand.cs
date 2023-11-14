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

            private readonly UserManager<AppUser> userManager;
            private readonly SignInManager<AppUser> signInManager;

            public SignInCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            }

            public async Task<SignInDto> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
               
                AppUser user = await userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new  Exception("cannot find user");
                }
                SignInResult result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                SignInDto signInDto = new SignInDto();
                if (result.Succeeded)
                {
                    signInDto.Success = true;
                    signInDto.Message = "successful signin";
                    return signInDto;
                }
                signInDto.Success = false;
                signInDto.Message = "signin successful";
                return signInDto;
            }
        }
    }
}
