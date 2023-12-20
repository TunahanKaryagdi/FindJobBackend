using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
