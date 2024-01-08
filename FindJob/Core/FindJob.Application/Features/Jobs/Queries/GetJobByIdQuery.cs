using Core.Utilities.Results;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using MediatR;

namespace FindJob.Application.Features.Jobs.Queries
{
    public class GetJobByIdQuery : IRequest<IDataResult<JobDto>>
    {
        public string Id { get; set; }
        public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, IDataResult<JobDto>>
        {
            private readonly IJobReadRepository _jobReadRepository;

            public GetJobByIdQueryHandler(IJobReadRepository jobReadRepository)
            {
                _jobReadRepository = jobReadRepository;
            }
            public async Task<IDataResult<JobDto>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                Job? job = await _jobReadRepository.ReadWithNavigations(request.Id);


                JobDto jobDto = new JobDto
                {
                    Id = job.Id.ToString(),
                    CreatedDate = job.CreatedDate,
                    Location = job.Location,
                    Company = new Company.Dtos.CompanyDto { Id = job.Company.Id.ToString(), CreatedDate = job.Company.CreatedDate, Name = job.Company.Name, UpdatedDate = job.Company.UpdatedDate },
                    Salary = job.Salary,
                    Type = job.Type,
                    Qualifications = job.Qualifications.Select(q => new QualificationDto { Id = q.Id.ToString(), JobId = q.JobId.ToString(), CreatedDate = q.CreatedDate, Name = q.Name, UpdatedDate = q.UpdatedDate }).ToList(),
                    User = new Users.Dtos.UserDto { Id = job.User.Id.ToString(), Email = job.User.Email, NameSurname = job.User.NameSurname },
                    Title = job.Title,
                    UpdatedDate = job.UpdatedDate,
                };
                return new SuccessDataResult<JobDto>(jobDto, "get job successfully");
            }
        }
    }
}
