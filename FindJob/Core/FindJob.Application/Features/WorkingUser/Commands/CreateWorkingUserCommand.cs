using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using FindJob.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.WorkingUser.Commands
{
    public class CreateWorkingUserCommand : IRequest<IResult>
    {

        public string UserId{ get; set; }
        public string CompanyId{ get; set; }
        public string Title { get; set; }

        public class CreateWorkingUserCommandHandler : IRequestHandler<CreateWorkingUserCommand, IResult>
        {
            IWorkingUserWriteRepository _workingUserWriteRepository;
            public CreateWorkingUserCommandHandler(IWorkingUserWriteRepository workingUserWriteRepository)
            {
                _workingUserWriteRepository = workingUserWriteRepository;
            }

            public async Task<IResult> Handle(CreateWorkingUserCommand request, CancellationToken cancellationToken)
            {
                await _workingUserWriteRepository.AddAsync(new Domain.Entities.WorkingUser
                {
                    CompanyId = Guid.Parse(request.CompanyId),
                    UserId = Guid.Parse(request.UserId),
                    Title = request.Title,
                });
                await _workingUserWriteRepository.SaveAsync();
                return new SuccessResult("successfully added");
            }
        }
    }
}
