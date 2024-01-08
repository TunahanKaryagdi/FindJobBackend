using Core.Utilities.Results;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Repositories;
using MediatR;

namespace FindJob.Application.Features.Jobs.Queries
{
    public class GetAllJobsQuery : IRequest<IDataResult<List<JobDto>>>
    {
        public int Page { get; set; } = 1;

        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, IDataResult<List<JobDto>>>
        {
            private readonly IJobReadRepository _jobReadRepository;

            public GetAllJobsQueryHandler(IJobReadRepository jobReadRepository)
            {
                _jobReadRepository = jobReadRepository;
            }

            public async Task<IDataResult<List<JobDto>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                List<JobDto> jobs = _jobReadRepository.GetAll().Skip((request.Page - 1) * 20).Take(20)
                    .Select(j => new JobDto()
                    {
                        Id = j.Id.ToString(),
                        CreatedDate = j.CreatedDate,
                        Location = j.Location,
                        Company = new Company.Dtos.CompanyDto { Id = j.Company.Id.ToString(), CreatedDate = j.Company.CreatedDate, Name = j.Company.Name, UpdatedDate = j.Company.UpdatedDate },
                        Salary = j.Salary,
                        Type = j.Type,
                        Qualifications = j.Qualifications.Select(q => new QualificationDto { Id = q.Id.ToString(), JobId = q.JobId.ToString(), CreatedDate = q.CreatedDate, Name = q.Name, UpdatedDate = q.UpdatedDate }).ToList(),
                        User = new Users.Dtos.UserDto { Id = j.User.Id.ToString(), Email = j.User.Email, NameSurname = j.User.NameSurname },
                        Title = j.Title,
                        UpdatedDate = j.UpdatedDate,
                    }).ToList();


                return new SuccessDataResult<List<JobDto>>(jobs, "successfully get data");

            }


        }
    }
}
