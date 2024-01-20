using FindJob.Application.Repositories.Application;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Applications.Commands
{
    public class CreateApplicationCommand : IRequest<IResult>
    {
        public string JobId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }

        public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, IResult>
        {

            IApplicationWriteRepository _applicationWriteRepository;

            public CreateApplicationCommandHandler(IApplicationWriteRepository applicationWriteRepository)
            {
                _applicationWriteRepository = applicationWriteRepository;
            }

            public async Task<IResult> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
            {
                await _applicationWriteRepository.AddAsync(new FindJob.Domain.Entities.Application
                {
                    UserId = Guid.Parse(request.UserId),
                    JobId = Guid.Parse(request.JobId),
                    Status = false,
                    Message = request.Message
                });
                await _applicationWriteRepository.SaveAsync();
                return new SuccessResult("successfully added");
            }
        }

    }
}
