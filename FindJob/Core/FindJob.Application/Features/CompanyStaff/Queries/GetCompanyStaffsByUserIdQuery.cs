using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.WorkingUser.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.WorkingUser.Queries
{
    public class GetCompanyStaffsByUserIdQuery : IRequest<IDataResult<List<CompanyStaffDto>>>
    {

        public string UserId { get; set; }

        public class GetCompaniesByUserIdQueryHandler : IRequestHandler<GetCompanyStaffsByUserIdQuery, IDataResult<List<CompanyStaffDto>>>
        {

            private readonly ICompanyStaffReadRepository _companyStaffReadRepository;

            public GetCompaniesByUserIdQueryHandler(ICompanyStaffReadRepository companyStaffReadRepository)
            {
                _companyStaffReadRepository = companyStaffReadRepository;
            }

            public async Task<IDataResult<List<CompanyStaffDto>>> Handle(GetCompanyStaffsByUserIdQuery request, CancellationToken cancellationToken)
            {
                var companyStaffs = _companyStaffReadRepository.GetWhere(w => w.UserId == Guid.Parse(request.UserId))
                .Select(j => new CompanyStaffDto()
                {
                    Company = new CompanyDto
                    {
                        Id = j.CompanyId.ToString(),
                        CreatedDate = j.CreatedDate,
                        UpdatedDate = j.UpdatedDate,
                        Name = j.Company.Name,
                        Image = j.Company.Image
                    },
                    User = new UserDto
                    {
                        Id = j.UserId.ToString(),
                        Image = j.User.Image,
                        Email = j.User.Email,
                        NameSurname = j.User.NameSurname
                    },
                    Title = j.Title
                }).ToList();

                return new SuccessDataResult<List<CompanyStaffDto>>(data: companyStaffs, "successfully");
            }
        }

    }
}
