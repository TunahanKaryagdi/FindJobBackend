using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.WorkingUser.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Application.Features.WorkingUser.Queries
{
    public class GetCurrentCompanyQuery : IRequest<IDataResult<CompanyStaffDto>>
    {

        public string UserId { get; set; }

        public class GetCurrentCompanyQueryHandler : IRequestHandler<GetCurrentCompanyQuery, IDataResult<CompanyStaffDto>>
        {

            private readonly ICompanyStaffReadRepository _companyStaffReadRepository;

            public GetCurrentCompanyQueryHandler(ICompanyStaffReadRepository companyStaffReadRepository)
            {
                _companyStaffReadRepository = companyStaffReadRepository;
            }

            public async Task<IDataResult<CompanyStaffDto?>> Handle(GetCurrentCompanyQuery request, CancellationToken cancellationToken)
            {
                var currentCompanyStaff = _companyStaffReadRepository
                    .GetWhere(w => w.UserId == Guid.Parse(request.UserId))
                    .Include(cs => cs.Company)
                    .Include(cs => cs.User)
                    .OrderByDescending(w => w.UpdatedDate)
                    .FirstOrDefault();

                if (currentCompanyStaff == null) return new SuccessDataResult<CompanyStaffDto?>(data: null, "successfully");

                CompanyStaffDto companyStaffDto = new CompanyStaffDto
                {
                    Company = new CompanyDto
                    {
                        Id = currentCompanyStaff.Company.Id.ToString(),
                        CreatedDate = currentCompanyStaff.Company.CreatedDate,
                        UpdatedDate = currentCompanyStaff.Company.UpdatedDate,
                        Name = currentCompanyStaff.Company.Name,
                        Image = currentCompanyStaff.Company.Image
                    },
                    User = new UserDto
                    {
                        Id = currentCompanyStaff.User.Id.ToString(),
                        Image = currentCompanyStaff.User.Image,
                        Email = currentCompanyStaff.User.Email,
                        NameSurname = currentCompanyStaff.User.NameSurname
                    },
                    Title = currentCompanyStaff.Title
                };



                return new SuccessDataResult<CompanyStaffDto?>(data: companyStaffDto, "successfully");
            }

        }

    }
}
