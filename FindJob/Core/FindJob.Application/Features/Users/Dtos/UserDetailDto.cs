using FindJob.Application.Features.Skill.Dtos;

namespace FindJob.Application.Features.Users.Dtos
{
    public class UserDetailDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string? Image { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}
