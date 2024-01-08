using Core.Utilities.Results;
using FindJob.Application.Features.Applications.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Repositories;
using MediatR;

namespace FindJob.Application.Features.Applications.Queries
{
    public class GetApplicationsByJobIdQuery : IRequest<IDataResult<List<ApplicationDto>>>
    {
        public string JobId { get; set; }

        public class GetApplicationsByJobIdQueryHandler : IRequestHandler<GetApplicationsByJobIdQuery, IDataResult<List<ApplicationDto>>>
        {
            IApplicationReadRepository _applicationReadRepository;

            public GetApplicationsByJobIdQueryHandler(IApplicationReadRepository applicationReadRepository)
            {
                _applicationReadRepository = applicationReadRepository;
            }


            public async Task<IDataResult<List<ApplicationDto>>> Handle(GetApplicationsByJobIdQuery request, CancellationToken cancellationToken)
            {
                List<ApplicationDto> applications = _applicationReadRepository.GetWhere(a => a.JobId == Guid.Parse(request.JobId)).Select(a =>

                    new ApplicationDto
                    {
                        Id = a.Id.ToString(),
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate,
                        Job = new Jobs.Dtos.JobDto
                        {
                            Id = a.Job.Id.ToString(),
                            CreatedDate = a.Job.CreatedDate,
                            UpdatedDate = a.Job.UpdatedDate,
                            Location = a.Job.Location,
                            Salary = a.Job.Salary,
                            Title = a.Job.Title,
                            Type = a.Job.Type,
                            Qualifications = a.Job.Qualifications.Select(q => new QualificationDto { Id = q.Id.ToString(), CreatedDate = q.CreatedDate, JobId = q.JobId.ToString(), Name = q.Name, UpdatedDate = q.UpdatedDate }).ToList(),
                            Company = new Company.Dtos.CompanyDto { Id = a.Job.Company.Id.ToString(), Name = a.Job.Company.Name, UpdatedDate = a.Job.Company.UpdatedDate, CreatedDate = a.Job.Company.CreatedDate },
                            User = new Users.Dtos.UserDto { Id = a.Job.User.Id.ToString(), Email = a.Job.User.Email, NameSurname = a.Job.User.NameSurname }
                        },
                        User = new Users.Dtos.UserDto
                        {
                            Id = a.User.Id.ToString(),
                            NameSurname = a.User.NameSurname,
                            Email = a.User.Email
                        },
                        Status = a.Status
                    }
                ).ToList();

                return new SuccessDataResult<List<ApplicationDto>>(data: applications, "succesfully");
            }
        }

    }
}
