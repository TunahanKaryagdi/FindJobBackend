using FindJob.Application.Abstractions.Token;

namespace FindJob.Application.Features.Users.Dtos
{
    public class SignInDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

    }
    public class SuccessSignInDto : SignInDto
    {
        public Token Token { get; set; }
    }

    public class ErrorSignInDto : SignInDto
    {

    }

}
