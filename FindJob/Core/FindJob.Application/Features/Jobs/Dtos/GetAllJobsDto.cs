
using FindJob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Jobs.Dtos
{
    public class GetAllJobsDto { 
        public List<JobDto> Jobs { get; set; }
    }


}
