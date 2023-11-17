using FindJob.Application.Abstractions.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Users.Dtos
{
    public class SignInWithGoogleDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

    }
    public class SuccessSignInWithGoogleDto : SignInWithGoogleDto
    {
        public Token Token { get; set; }
    }

    public class ErrorSignInWithGoogleDto : SignInWithGoogleDto
    {

    }
}
