using FindJob.Application.Abstractions;
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

        private readonly IJobService _jobService;
        private readonly IJobWriteRepository _jobWriteRepository;

        public JobsController(IJobService jobService, IJobWriteRepository jobWriteRepository)
        {
            _jobService = jobService;
            _jobWriteRepository = jobWriteRepository;
        }

        [HttpGet("getall")]
        public async void Get()
        {
            await _jobWriteRepository.AddRangeAsync(new()
            {
                new Job(){Id = Guid.NewGuid(),Date = DateTime.UtcNow,Description = "Good Description",Location = "Konya", Title = "Title Nice"},
                new Job(){Id = Guid.NewGuid(),Date = DateTime.UtcNow,Description = "Good Description2",Location = "Konya", Title = "Title Nice2"},
                new Job(){Id = Guid.NewGuid(),Date = DateTime.UtcNow,Description = "Good Description3",Location = "Konya", Title = "Title Nice3"},
            });
            await _jobWriteRepository.SaveAsync();
                
        }
    }
}
