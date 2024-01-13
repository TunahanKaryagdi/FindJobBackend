using FindJob.Domain.Entities.Common;

namespace FindJob.Domain.Entities
{
    public class Qualification : BaseEntity
    {
        public string Name { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public int Experience { get; set; }
    }
}
