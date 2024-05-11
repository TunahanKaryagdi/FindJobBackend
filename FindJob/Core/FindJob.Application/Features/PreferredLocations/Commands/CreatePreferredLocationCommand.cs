using FindJob.Application.Repositories.PreferredLocation;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.PreferredLocations.Commands
{
    public class CreatePreferredLocationCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string UserId { get; set; }


        public class CreatePreferredLocationCommandHandler : IRequestHandler<CreatePreferredLocationCommand, IResult>
        {
            IPreferredLocationWriteRepository _preferredLocationWriteRepository;

            public CreatePreferredLocationCommandHandler(IPreferredLocationWriteRepository preferredLocationWriteRepository)
            {
                _preferredLocationWriteRepository = preferredLocationWriteRepository;
            }

            public async Task<IResult> Handle(CreatePreferredLocationCommand request, CancellationToken cancellationToken)
            {
                await _preferredLocationWriteRepository.AddAsync(new Domain.Entities.PreferredLocation { UserId = Guid.Parse(request.UserId), Name = request.Name });
                await _preferredLocationWriteRepository.SaveAsync();
                return new SuccessResult("");
            }
        }
    }
}
