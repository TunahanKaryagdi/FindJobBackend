using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Companies.Queries
{
    public class GetAllCompaniesQuery : IRequest<IDataResult<List<CompanyDto>>>
    {

        public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IDataResult<List<CompanyDto>>>
        {
            private readonly ICompanyReadRepository _companyReadRepository;

            public GetAllCompaniesQueryHandler(ICompanyReadRepository companyReadRepository)
            {
                _companyReadRepository = companyReadRepository;
            }

            public async Task<IDataResult<List<CompanyDto>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
            {
                List<CompanyDto> companies = _companyReadRepository.GetAll()
                    .Select(j => new CompanyDto()
                    {
                        Id = j.Id.ToString(),
                        Name = j.Name,
                        CreatedDate = j.CreatedDate,
                        UpdatedDate = j.UpdatedDate,
                        Image = j.Image
                    }).ToList();
                return new SuccessDataResult<List<CompanyDto>>(companies, "successfully get data");
            }
        }

    }
}
