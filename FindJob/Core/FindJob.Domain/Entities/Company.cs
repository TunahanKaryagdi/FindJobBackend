using FindJob.Domain.Entities.Common;

namespace FindJob.Domain.Entities
{
    public class Company : BaseEntity
    {

        public string Name { get; set; }
        public string? Image { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
