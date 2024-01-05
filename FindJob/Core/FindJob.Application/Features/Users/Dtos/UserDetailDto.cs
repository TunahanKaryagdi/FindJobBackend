using FindJob.Application.Features.Skill.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Users.Dtos
{
    public class UserDetailDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}
