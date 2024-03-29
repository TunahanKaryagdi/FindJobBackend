﻿using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Jobs.Commands
{
    public class DeleteJobByIdCommand : IRequest<IResult>
    {
        public string Id { get; set; }

        public class DeleteJobByIdCommandHandler : IRequestHandler<DeleteJobByIdCommand, IResult>
        {
            private readonly IJobWriteRepository _jobWriteRepository;

            public DeleteJobByIdCommandHandler(IJobWriteRepository jobWriteRepository)
            {
                _jobWriteRepository = jobWriteRepository;
            }

            public async Task<IResult> Handle(DeleteJobByIdCommand request, CancellationToken cancellationToken)
            {
                bool isSuccess = await _jobWriteRepository.RemoveAsync(request.Id);
                await _jobWriteRepository.SaveAsync();
                return isSuccess ? new SuccessResult("deleted successfully") : new ErrorResult("delete failed");
            }
        }
    }
}
