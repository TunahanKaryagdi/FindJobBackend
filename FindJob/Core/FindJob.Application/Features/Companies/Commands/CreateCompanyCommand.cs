using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Enums;
using FindJob.Application.Utilities.File;
using FindJob.Application.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FindJob.Application.Features.Company.Commands
{
    public class CreateCompanyCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public IFormFile? File { get; set; }


        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, IResult>
        {

            private readonly ICompanyWriteRepository _companyWriteRepository;
            private readonly IFileHelper _fileHelper;

            public CreateCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository, IFileHelper fileHelper)
            {
                _companyWriteRepository = companyWriteRepository;
                _fileHelper = fileHelper;
            }

            public async Task<IResult> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                string? ImagePath = null;

                if (request.File != null)
                {
                    ImagePath = _fileHelper.Upload(request.File, ImageType.Company);
                }


                await _companyWriteRepository.AddAsync(new Domain.Entities.Company()
                {
                    Name = request.Name,
                    Image = ImagePath
                });
                await _companyWriteRepository.SaveAsync();
                return new SuccessResult("successfull");
            }
        }
    }
}
