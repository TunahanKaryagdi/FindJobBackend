using FindJob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Abstractions
{
    public interface IJobService
    {
        List<Job> GetJobs();
    }
}
