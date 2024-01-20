namespace FindJob.Application.Features.Company.Dtos
{
    public class CompanyDto
    {

        public string Name { get; set; }
        public string Id { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
