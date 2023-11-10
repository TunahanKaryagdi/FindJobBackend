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
    public class CreateJobCommand : IRequest<CreateJobDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }



        public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, CreateJobDto>
        {
            private readonly IJobWriteRepository _jobWriteRepository;
            public CreateJobCommandHandler(IJobWriteRepository jobWriteRepository)
            {
                _jobWriteRepository = jobWriteRepository;
            }

            public async Task<CreateJobDto> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {

                bool isSuccess = await _jobWriteRepository.AddAsync(new Job() { Description = request.Description, Location = request.Location, Title = request.Title });
                _jobWriteRepository.SaveAsync();
                return new CreateJobDto
                {
                    Message = isSuccess ? "successfully added" : "addition failed"

                };

            }
        }

    }
}
