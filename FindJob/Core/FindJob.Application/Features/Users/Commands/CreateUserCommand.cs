using FindJob.Application.Features.Users.Dtos;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<CreateUserDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
        {

            private readonly UserManager<AppUser> _userManager;

            public CreateUserCommandHandler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    UserName = Guid.NewGuid().ToString(),
                }, request.Password);
               
                CreateUserDto createUserDto = new CreateUserDto();
                if (result.Succeeded)
                {
                    createUserDto.Success = true;
                    createUserDto.Message = "Successful register";
                    return createUserDto;
                }
                createUserDto.Success = false;
                createUserDto.Message = "Register failed";
                return createUserDto;   

            }
        }


    }
}
