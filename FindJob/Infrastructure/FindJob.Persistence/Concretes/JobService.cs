using FindJob.Application.Abstractions;
using FindJob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Concretes
{
    public class JobService : IJobService
    {
        public List<Job> GetJobs()
        {
            return new List<Job> { 
                new Job() { Id = Guid.NewGuid(),Date = DateTime.Now,Description = "Job description",Title = "Job title",Location = "Konya" } ,
                new Job() { Id = Guid.NewGuid(),Date = DateTime.Now,Description = "Job description2",Title = "Job title2",Location = "Konya2" } ,
                new Job() { Id = Guid.NewGuid(),Date = DateTime.Now,Description = "Job description3",Title = "Job title3",Location = "Konya3" } ,

            };
        }
    }
}
