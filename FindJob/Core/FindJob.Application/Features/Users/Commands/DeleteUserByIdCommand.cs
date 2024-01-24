using FindJob.Application.Utilities.Results;
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
    public class DeleteUserByIdCommand : IRequest<IResult> 
    {
        public string Id{ get; set; }

        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, IResult>
        {
            UserManager<AppUser> _userManager;

            public DeleteUserByIdCommandHandler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<IResult> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _userManager.FindByIdAsync(request.Id);
                if (user != null)
                {
                   IdentityResult result =  await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return new SuccessResult("successfully deleted");
                    }
                }
                return new SuccessResult("");
            }
        }
    }
}
