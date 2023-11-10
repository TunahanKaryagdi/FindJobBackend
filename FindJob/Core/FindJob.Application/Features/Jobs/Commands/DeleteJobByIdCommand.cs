using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Jobs.Commands
{
    public class DeleteJobByIdCommand : IRequest<DeleteJobByIdDto>
    {
        public string Id { get; set; }

        public class DeleteJobByIdCommandHandler : IRequestHandler<DeleteJobByIdCommand, DeleteJobByIdDto>
        {
            private readonly IJobWriteRepository _jobWriteRepository;

            public DeleteJobByIdCommandHandler(IJobWriteRepository jobWriteRepository)
            {
                _jobWriteRepository = jobWriteRepository;
            }

            public async Task<DeleteJobByIdDto> Handle(DeleteJobByIdCommand request, CancellationToken cancellationToken)
            {
                bool isSuccess = await _jobWriteRepository.RemoveAsync(request.Id);
                _jobWriteRepository.SaveAsync();
                return new DeleteJobByIdDto()
                {
                    Message = isSuccess ? "Successfully Deleted ": "Deletion Failed" 
                };
            }
        }
    }
}
