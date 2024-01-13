using Core.Utilities.Results;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Repositories;
using MediatR;

namespace FindJob.Application.Features.Jobs.Queries
{
    public class GetJobsByUserIdQuery : IRequest<IDataResult<List<JobDto>>>
    {
        public string UserId { get; set; }

        public class GetJobsByUserIdQueryHandler : IRequestHandler<GetJobsByUserIdQuery, IDataResult<List<JobDto>>>
        {

            IJobReadRepository _jobReadRepository;

            public GetJobsByUserIdQueryHandler(IJobReadRepository jobReadRepository)
            {
                _jobReadRepository = jobReadRepository;
            }

            public async Task<IDataResult<List<JobDto>>> Handle(GetJobsByUserIdQuery request, CancellationToken cancellationToken)
            {
                List<JobDto> jobs = _jobReadRepository.GetWhere(j => j.UserId == Guid.Parse(request.UserId))
                     .Select(j => new JobDto()
                     {
                         Id = j.Id.ToString(),
                         CreatedDate = j.CreatedDate,
                         Location = j.Location,
                         Company = new Company.Dtos.CompanyDto { Id = j.Company.Id.ToString(), CreatedDate = j.Company.CreatedDate, Name = j.Company.Name, UpdatedDate = j.Company.UpdatedDate },
                         Salary = j.Salary,
                         Type = j.Type,
                         Qualifications = j.Qualifications.Select(q => new QualificationDto { Id = q.Id.ToString(), JobId = q.JobId.ToString(), CreatedDate = q.CreatedDate, Name = q.Name, UpdatedDate = q.UpdatedDate, Experience = q.Experience }).ToList(),
                         User = new Users.Dtos.UserDto { Id = j.User.Id.ToString(), Email = j.User.Email, NameSurname = j.User.NameSurname },
                         Title = j.Title,
                         UpdatedDate = j.UpdatedDate,
                     }).ToList();

                return new SuccessDataResult<List<JobDto>>(jobs, "");
            }
        }
    }
}
