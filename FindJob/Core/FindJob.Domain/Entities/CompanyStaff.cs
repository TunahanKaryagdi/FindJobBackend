using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class CompanyStaff : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public AppUser User { get; set; }
        public string Title { get; set; }

    }
}
