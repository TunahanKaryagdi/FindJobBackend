using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Domain.Entities
{
    public class Application : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public AppUser User { get; set; }
        public Job Job { get; set; }

    }
}
