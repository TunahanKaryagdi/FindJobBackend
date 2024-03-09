using FindJob.Application.Abstractions.Token;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Application.Features.Users.Commands
{
    public class SignInWithGoogleCommand : IRequest<SignInWithGoogleDto>
    {
        public string Id { get; set; }
        public string IdToken { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }

        public class SignInWithGoogleCommandHandler : IRequestHandler<SignInWithGoogleCommand, SignInWithGoogleDto>
        {

            private readonly UserManager<AppUser> _userManager;
            private readonly ITokenHelper _tokenHelper;

            public SignInWithGoogleCommandHandler(UserManager<AppUser> userManager, ITokenHelper tokenHelper)
            {
                _userManager = userManager;
                _tokenHelper = tokenHelper;
            }

            public async Task<SignInWithGoogleDto> Handle(SignInWithGoogleCommand request, CancellationToken cancellationToken)
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<String> { "149429631601-56vf5u2b3t2v83sqpvb9i4m41nktlp3i.apps.googleusercontent.com" }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
                var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);
                AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                //info dış kaynaktaki bilgileri ve veri tabanında ayrı bir tablodu tutulmaktadır.
                bool result = user != null;
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(payload.Email);
                    if (user == null)
                    {
                        user = new AppUser()
                        {
                            Id = Guid.NewGuid(),
                            Email = payload.Email,
                            UserName = payload.Email,
                            NameSurname = payload.Name
                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        result = identityResult.Succeeded;
                    }
                }
                if (result)
                    await _userManager.AddLoginAsync(user, info);
                else
                    throw new Exception("Invalid external authentication");

                var roles = await _userManager.GetRolesAsync(user);
                string token = _tokenHelper.CreateAccessToken(user.Id.ToString(), roles.ToList());

                return new SuccessSignInWithGoogleDto()
                {
                    Token = token,
                    Success = true,
                    Message = "Successfully login"
                };
            }
        }
    }
}
