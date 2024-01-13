using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
