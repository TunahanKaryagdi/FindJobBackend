using FindJob.Application.Repositories;
using FindJob.Application.Repositories.Application;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Applications.Commands
{
    public class UpdateApplicationByIdCommand : IRequest<IResult>
    {
        public string Id { get; set; }
        public bool Status { get; set; }


        public class UpdateApplicationByIdCommandHandler : IRequestHandler<UpdateApplicationByIdCommand, IResult>
        {
            IApplicationWriteRepository _applicationWriteRepository;
            IApplicationReadRepository _applicationReadRepository;

            public UpdateApplicationByIdCommandHandler(IApplicationWriteRepository applicationWriteRepository, IApplicationReadRepository applicationReadRepository)
            {
                _applicationWriteRepository = applicationWriteRepository;
                _applicationReadRepository = applicationReadRepository;
            }

            public async Task<IResult> Handle(UpdateApplicationByIdCommand request, CancellationToken cancellationToken)
            {
                FindJob.Domain.Entities.Application application = await _applicationReadRepository.GetByIdAsync(request.Id);
                application.Status = request.Status;
                _applicationWriteRepository.Update(application);
                await _applicationWriteRepository.SaveAsync();
                return new SuccessResult("Updated application");
            }
        }


    }
}
