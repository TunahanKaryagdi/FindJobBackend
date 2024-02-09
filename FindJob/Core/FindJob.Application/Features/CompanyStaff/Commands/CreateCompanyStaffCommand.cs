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
    public class CreateCompanyStaffCommand : IRequest<IResult>
    {

        public string UserId{ get; set; }
        public string CompanyId{ get; set; }
        public string Title { get; set; }

        public class CreateWorkingUserCommandHandler : IRequestHandler<CreateCompanyStaffCommand, IResult>
        {
            ICompanyStaffWriteRepository _companyStaffWriteRepository;

            public CreateWorkingUserCommandHandler(ICompanyStaffWriteRepository companyStaffWriteRepository)
            {
                _companyStaffWriteRepository = companyStaffWriteRepository;
            }

            public async Task<IResult> Handle(CreateCompanyStaffCommand request, CancellationToken cancellationToken)
            {
                await _companyStaffWriteRepository.AddAsync(new Domain.Entities.CompanyStaff
                {
                    CompanyId = Guid.Parse(request.CompanyId),
                    UserId = Guid.Parse(request.UserId),
                    Title = request.Title,
                });
                await _companyStaffWriteRepository.SaveAsync();
                return new SuccessResult("successfully added");
            }
        }
    }
}
