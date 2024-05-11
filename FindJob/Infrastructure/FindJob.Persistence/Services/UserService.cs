using FindJob.Application.Features.PreferredLocations.Dtos;
using FindJob.Application.Features.Skill.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Services;
using FindJob.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Persistence.Services
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public List<UserDetailDto> GetAllUsers()
        {
            List<UserDetailDto> users = _userManager.Users
                .Select(u => new UserDetailDto()
                {
                    Email = u.Email,
                    Id = u.Id.ToString(),
                    Image = u.Image,
                    NameSurname = u.NameSurname,
                    Skills = u.Skills.Select(s => new SkillDto { Id = s.Id.ToString(), CreatedDate = s.CreatedDate, Experience = s.Experience, Name = s.Name, UpdatedDate = s.UpdatedDate, UserId = s.UserId.ToString() }).ToList(),
                    PreferredLocations = u.PreferredLocations.Select(p => new PreferredLocationDto { UserId = p.UserId.ToString(), Name = p.Name }).ToList()
                }).ToList();
            return users;
        }

        public async Task<UserDetailDto> GetUserById(string id)
        {
            AppUser user = await _userManager.Users
                    .Include(u => u.Skills)
                    .Include(u => u.PreferredLocations)
                    .SingleOrDefaultAsync(u => u.Id == Guid.Parse(id));
            if (user == null)
            {
                throw new Exception("user not found");
            }

            UserDetailDto userDetailDto = new UserDetailDto
            {
                Email = user.Email,
                Id = user.Id.ToString(),
                NameSurname = user.NameSurname,
                Skills = user.Skills.Select(x => new SkillDto { Id = x.Id.ToString(), CreatedDate = x.CreatedDate, UpdatedDate = x.UpdatedDate, Name = x.Name, UserId = x.UserId.ToString(), Experience = x.Experience }).ToList(),
                Image = user.Image,
                PreferredLocations = user.PreferredLocations.Select(x => new PreferredLocationDto { UserId = x.UserId.ToString(), Name = x.Name }).ToList(),
            };
            return userDetailDto;
        }
    }
}
