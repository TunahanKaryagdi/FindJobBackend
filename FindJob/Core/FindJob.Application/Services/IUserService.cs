using FindJob.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Services
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserById(string id);
    }
}
