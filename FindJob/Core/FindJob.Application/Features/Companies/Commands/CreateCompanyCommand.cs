using Core.Utilities.Results;
using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Company.Commands
{
    public class CreateCompanyCommand : IRequest<IResult>
    {
        public string Name { get; set; }


        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, IResult>
        {

            private readonly ICompanyWriteRepository _companyWriteRepository;

            public CreateCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository)
            {
                _companyWriteRepository = companyWriteRepository;
            }

            public async Task<IResult> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                await _companyWriteRepository.AddAsync(new Domain.Entities.Company()
                {
                    Name = request.Name,
                });
                await _companyWriteRepository.SaveAsync();
                return new SuccessResult("successfull");
            }
        }
    }
}
