using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Qualification.Dtos;
using FindJob.Application.Features.WorkingUser.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.WorkingUser.Queries
{
    public class GetCompaniesByUserIdQuery : IRequest<IDataResult<List<WorkingUserDto>>>
    {

        public string UserId { get; set; }

        public class GetCompaniesByUserIdQueryHandler : IRequestHandler<GetCompaniesByUserIdQuery, IDataResult<List<WorkingUserDto>>>
        {

            private readonly IWorkingUserReadRepository _workingUserReadRepository;

            public GetCompaniesByUserIdQueryHandler(IWorkingUserReadRepository workingUserReadRepository)
            {
                _workingUserReadRepository = workingUserReadRepository;
            }

            public async Task<IDataResult<List<WorkingUserDto>>> Handle(GetCompaniesByUserIdQuery request, CancellationToken cancellationToken)
            {
                var companies = _workingUserReadRepository.GetWhere(w => w.UserId == Guid.Parse(request.UserId))
                .Select(j => new WorkingUserDto()
                {
                    Company = new CompanyDto
                    {
                        Id = j.CompanyId.ToString(),
                        CreatedDate = j.CreatedDate,
                        UpdatedDate = j.UpdatedDate,
                        Name = j.Company.Name,
                        Image = j.Company.Image
                    },
                    Title = j.Title
                }).ToList();

                return new SuccessDataResult<List<WorkingUserDto>>(data: companies, "successfully");
            }
        }

    }
}
