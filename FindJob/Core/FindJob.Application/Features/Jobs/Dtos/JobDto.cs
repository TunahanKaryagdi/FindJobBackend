using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Features.Users.Dtos;

namespace FindJob.Application.Features.Jobs.Dtos
{
    public class JobDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public List<QualificationDto> Qualifications { get; set; }
        public double Salary { get; set; }
        public CompanyDto Company { get; set; }
        public string Type { get; set; }
        public UserDto User { get; set; }
    }
}
