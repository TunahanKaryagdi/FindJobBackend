using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Qualification.Dtos
{
    public class QualificationDto
    {
        public string JobId { get; set; }
        public string Name  { get; set; }
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
