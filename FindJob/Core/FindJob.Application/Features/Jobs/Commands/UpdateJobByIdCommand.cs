using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using FindJob.Domain.Entities;
using MediatR;

namespace FindJob.Application.Features.Jobs.Commands
{
    public class UpdateJobByIdCommand : IRequest<IDataResult<Job>>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }

        public class UpdateJobByIdCommandHandler : IRequestHandler<UpdateJobByIdCommand, IDataResult<Job>>
        {

            private readonly IJobWriteRepository _jobWriteRepository;
            private readonly IJobReadRepository _jobReadRepository;

            public UpdateJobByIdCommandHandler(IJobReadRepository jobReadRepository, IJobWriteRepository jobWriteRepository)
            {
                _jobReadRepository = jobReadRepository;
                _jobWriteRepository = jobWriteRepository;
            }


            public async Task<IDataResult<Job>> Handle(UpdateJobByIdCommand request, CancellationToken cancellationToken)
            {

                Job job = await _jobReadRepository.GetByIdAsync(request.Id);
                job.Title = request.Title;
                job.Location = request.Location;
                job.Type = request.Type;
                job.UserId = Guid.Parse(request.UserId);
                job.CompanyId = Guid.Parse(request.CompanyId);

                bool isSuccess = _jobWriteRepository.Update(job);
                await _jobWriteRepository.SaveAsync();
                return new SuccessDataResult<Job>("job updated");
            }
        }
    }
}
