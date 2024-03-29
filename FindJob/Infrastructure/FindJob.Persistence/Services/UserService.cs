﻿using FindJob.Application.Features.Skill.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Services;
using FindJob.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Persistence.Services
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager;
        ISkillReadRepository _skillReadRepository;

        public UserService(ISkillReadRepository skillReadRepository, UserManager<AppUser> userManager)
        {
            _skillReadRepository = skillReadRepository;
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
                    Skills = u.Skills.Select(s => new SkillDto { Id = s.Id.ToString(), CreatedDate = s.CreatedDate, Experience = s.Experience, Name = s.Name, UpdatedDate = s.UpdatedDate, UserId = s.UserId.ToString() }).ToList()

                }).ToList();
            return users;
        }

        public async Task<UserDetailDto> GetUserById(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            List<SkillDto> skillDtos = _skillReadRepository.GetWhere(x => x.UserId == Guid.Parse(id)).Select(x => new SkillDto { Id = x.Id.ToString(), CreatedDate = x.CreatedDate, UpdatedDate = x.UpdatedDate, Name = x.Name, UserId = x.UserId.ToString(), Experience = x.Experience }).ToList();
            UserDetailDto userDetailDto = new UserDetailDto
            {
                Email = user.Email,
                Id = user.Id.ToString(),
                NameSurname = user.NameSurname,
                Skills = skillDtos,
                Image = user.Image
            };
            return userDetailDto;
        }
    }
}
