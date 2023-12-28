using Core.Utilities.Results;
using FindJob.Application.Repositories.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Applications.Commands
{
    public class CreateApplicationCommand : IRequest<IResult>
    {
        public string JobId { get; set; }
        public string UserId { get; set; }

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
                });
                await _applicationWriteRepository.SaveAsync();
                return new SuccessResult { };
            }
        }

    }
}
