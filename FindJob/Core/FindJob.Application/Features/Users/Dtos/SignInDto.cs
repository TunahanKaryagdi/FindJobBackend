using FindJob.Application.Abstractions.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
