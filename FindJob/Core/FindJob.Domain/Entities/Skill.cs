using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public AppUser User{ get; set;}

    }
}
