using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Users.Dtos;

namespace FindJob.Application.Features.WorkingUser.Dtos
{
    public class CompanyStaffDto
    {
        public CompanyDto Company { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
    }
}
