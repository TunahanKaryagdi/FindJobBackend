using FindJob.Application.Features.Jobs.Commands;
using FindJob.Application.Repositories;
using FindJob.Application.Services;
using FindJob.Domain.Entities;

namespace FindJob.Persistence.Services
{
    public class JobService : IJobService
    {

        //IQualificationWriteRepository _qualificationWriteRepository;
        IJobWriteRepository _jobWriteRepository;

        public JobService(IQualificationWriteRepository qualificationWriteRepository, IJobWriteRepository jobWriteRepository)
        {
            _jobWriteRepository = jobWriteRepository;
            //_qualificationWriteRepository = qualificationWriteRepository;
        }

        public async Task<Job> CreateJob(Job job)
        {

            var newJob = await _jobWriteRepository.AddAsync(job); 

            await _jobWriteRepository.SaveAsync();

            //IEnumerable<Qualification> qualifications = job.Qualifications.Select(q => new Qualification { JobId = job.Id, Name = q.Name }); 
            //_= await  _qualificationWriteRepository.AddRangeAsync(qualifications.ToList());
            //await _qualificationWriteRepository.SaveAsync();

            return newJob; 
        }
    }
}
