using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;

namespace FindJob.Domain.Entities
{
    public class Application : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public AppUser User { get; set; }
        public Job Job { get; set; }

    }
}
