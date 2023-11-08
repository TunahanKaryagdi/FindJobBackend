using FindJob.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Domain.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        //Category
        public ICollection<Category> Categories { get; set; }

    }
}
