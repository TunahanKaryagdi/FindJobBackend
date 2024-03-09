using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.WorkingUser.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.CompanyStaff.Queries
{
    public class GetCompanyStaffsByCompanyIdQuery : IRequest<IDataResult<List<CompanyStaffDto>>>
    {

        public string CompanyId { get; set; }

        public class GetUsersByCompanyIdQueryHandler : IRequestHandler<GetCompanyStaffsByCompanyIdQuery, IDataResult<List<CompanyStaffDto>>>
        {

            private readonly ICompanyStaffReadRepository _companyStaffReadRepository;

            public GetUsersByCompanyIdQueryHandler(ICompanyStaffReadRepository companyStaffReadRepository)
            {
                _companyStaffReadRepository = companyStaffReadRepository;
            }

            public async Task<IDataResult<List<CompanyStaffDto>>> Handle(GetCompanyStaffsByCompanyIdQuery request, CancellationToken cancellationToken)
            {
                var companyStaffs = _companyStaffReadRepository.GetWhere(w => w.CompanyId == Guid.Parse(request.CompanyId))
                .Select(j => new CompanyStaffDto()
                {
                    User = new UserDto
                    {
                        Id = j.UserId.ToString(),
                        Image = j.User.Image,
                        Email = j.User.Email,
                        NameSurname = j.User.NameSurname
                    },
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

                return new SuccessDataResult<List<CompanyStaffDto>>(data: companyStaffs, "successfully");
            }
        }

    }
}
