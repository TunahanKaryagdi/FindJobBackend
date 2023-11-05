using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly IJobWriteRepository _jobWriteRepository;
        private readonly IJobReadRepository _jobReadRepository;


        public JobsController(IJobWriteRepository jobWriteRepository, IJobReadRepository jobReadRepository)
        {
            _jobWriteRepository = jobWriteRepository;
            _jobReadRepository = jobReadRepository;
        }

        [HttpGet("get")]
        public async Task Get()
        {

            await _jobWriteRepository.AddAsync(new Job() { Title = "Title", Description = "Description", Location = "Konya" });
            await _jobWriteRepository.SaveAsync();
                
        }
        [HttpGet("getall")]
        public IQueryable<Job> GetAll()
        {
            return _jobReadRepository.GetAll();
        }

    }
}
