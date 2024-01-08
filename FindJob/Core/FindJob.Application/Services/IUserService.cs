using FindJob.Application.Features.Users.Dtos;

namespace FindJob.Application.Services
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserById(string id);
    }
}
