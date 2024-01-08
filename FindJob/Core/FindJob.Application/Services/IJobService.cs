using FindJob.Domain.Entities;

namespace FindJob.Application.Services
{
    public interface IJobService
    {
        Task<Job> CreateJob(Job job);


    }
}
