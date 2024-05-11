using FindJob.Application.Utilities.Enums;
using FindJob.Application.Utilities.File;
using FindJob.Application.Utilities.Results;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<IResult>
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PreferredLocation { get; set; }
        public IFormFile? File { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IFileHelper _fileHelper;

            public UpdateUserCommandHandler(UserManager<AppUser> userManager, IFileHelper fileHelper)
            {
                _userManager = userManager;
                _fileHelper = fileHelper;
            }

            public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {

                AppUser user = await _userManager.FindByIdAsync(request.Id);
                user.NameSurname = request.NameSurname;
                user.Email = request.Email;

                if (request.File != null)
                {
                    user.Image = _fileHelper.Upload(request.File, ImageType.User);
                }
                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return new SuccessResult("successfully updated");
                }
                return new ErrorResult("something went wrong");
            }
        }
    }
}
