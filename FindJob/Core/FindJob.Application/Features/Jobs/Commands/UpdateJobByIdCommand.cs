using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Jobs.Commands
{
    public class UpdateJobByIdCommand : IRequest<UpdateJobDto>
    {
        public string Id { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public string Location { get; set;}

        public class UpdateJobByIdCommandHandler : IRequestHandler<UpdateJobByIdCommand, UpdateJobDto>
        {

            private readonly IJobWriteRepository _jobWriteRepository;
            public UpdateJobByIdCommandHandler(IJobWriteRepository jobWriteRepository)
            {
                _jobWriteRepository = jobWriteRepository;
            }
            public async Task<UpdateJobDto> Handle(UpdateJobByIdCommand request, CancellationToken cancellationToken)
            {
                bool isSuccess =  _jobWriteRepository.Update(new Job() { Id = Guid.Parse(request.Id), Title = request.Title, Description = request.Description, Location = request.Location, UpdatedDate = DateTime.UtcNow });
                _jobWriteRepository.SaveAsync();
                return new UpdateJobDto()
                {
                    Message = isSuccess ? "Successfully updated" : "Update failed"
                };
            }
        }
    }
}
