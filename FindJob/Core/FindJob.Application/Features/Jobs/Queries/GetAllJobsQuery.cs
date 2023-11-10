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
    public class GetAllJobsQuery : IRequest<GetAllJobsDto>
    {
        public int PageNumber { get; set; } = 0;

        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, GetAllJobsDto>
        {
            private readonly IJobReadRepository _jobReadRepository;

            public GetAllJobsQueryHandler(IJobReadRepository jobReadRepository)
            {
                _jobReadRepository = jobReadRepository;
            }

            public async Task<GetAllJobsDto> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                int TotalCount = _jobReadRepository.GetAll().Count();
                List<JobDto> jobs = _jobReadRepository.GetAll().Skip(request.PageNumber * 20).Take(20)
                    .Select(j => new JobDto()
                    {
                        Id = j.Id.ToString(),
                        CreatedDate = j.CreatedDate,
                        Description = j.Description,
                        Location = j.Location,
                        Title = j.Title,
                        UpdatedDate =j.UpdatedDate,
                        Categories = j.Categories
                    }).ToList();


                return new GetAllJobsDto()
                {
                    Jobs = jobs,
                };
            }
        }
    }
}
