using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class PreferredLocation : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
