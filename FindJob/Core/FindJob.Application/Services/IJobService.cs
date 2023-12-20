using FindJob.Application.Features.Jobs.Commands;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Services
{
    public interface IJobService
    {
        Task<Job> CreateJob(Job job);


    }
}
