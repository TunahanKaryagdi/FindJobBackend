using Core.Utilities.Results;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Services;
using FindJob.Domain.Entities;
using MediatR;

namespace FindJob.Application.Features.Jobs.Commands
{
    public class CreateJobCommand : IRequest<IResult>
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public double Salary { get; set; }
        public List<CreateQualificationDto> Qualifications { get; set; }
        public string Type { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }



        public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, IResult>
        {
            private readonly IJobService _jobService;

            public CreateJobCommandHandler(IJobService jobService)
            {
                _jobService = jobService;
            }

            public async Task<IResult> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {

                Job job = await _jobService.CreateJob(new Job
                {
                    Title = request.Title,
                    Location = request.Location,
                    Salary = request.Salary,
                    Type = request.Type,
                    Qualifications = request.Qualifications.Select(q => new Domain.Entities.Qualification { Name = q.Name }).ToList(),
                    CompanyId = Guid.Parse(request.CompanyId),
                    UserId = Guid.Parse(request.UserId),
                });


                return new SuccessResult("successfully added");

            }
        }

    }
}
