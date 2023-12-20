using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class Job : BaseEntity
    {

        public string Title { get; set; }
        public string Location { get; set; }
        public double Salary { get; set; }
        public string Type { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }

    }

}
