using FindJob.Application.Abstractions.Token;

namespace FindJob.Application.Features.Users.Dtos
{
    public class SignInWithGoogleDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

    }
    public class SuccessSignInWithGoogleDto : SignInWithGoogleDto
    {
        public string Token { get; set; }
    }

    public class ErrorSignInWithGoogleDto : SignInWithGoogleDto
    {

    }
}
