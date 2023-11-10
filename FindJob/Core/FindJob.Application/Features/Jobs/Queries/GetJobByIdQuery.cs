using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Jobs.Queries
{
    public class GetJobByIdQuery : IRequest<JobDto>
    {
        public string Id { get; set; }
        public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, JobDto>
        {
            private readonly IJobReadRepository _jobReadRepository;

            public GetJobByIdQueryHandler(IJobReadRepository jobReadRepository)
            {
                _jobReadRepository = jobReadRepository;
            }
            public async Task<JobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                Job job = await  _jobReadRepository.GetByIdAsync(request.Id);
                return new JobDto()
                {
                    Id = job.Id.ToString(),
                    CreatedDate = job.CreatedDate,
                    Description = job.Description,
                    Location = job.Location,
                    Title = job.Title,
                    Categories = job.Categories,
                    UpdatedDate = job.UpdatedDate,
                };
            }
        }
    }
}
