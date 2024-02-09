using FindJob.Application.Features.Company.Dtos;
using FindJob.Application.Features.CompanyStaff.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Features.WorkingUser.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.CompanyStaff.Queries
{
    public class GetUsersByCompanyIdQuery : IRequest<IDataResult<List<UserStaffDto>>>
    {

        public string CompanyId { get; set; }

        public class GetUsersByCompanyIdQueryHandler : IRequestHandler<GetUsersByCompanyIdQuery, IDataResult<List<UserStaffDto>>>
        {

            private readonly ICompanyStaffReadRepository _companyStaffReadRepository;

            public GetUsersByCompanyIdQueryHandler(ICompanyStaffReadRepository companyStaffReadRepository)
            {
                _companyStaffReadRepository = companyStaffReadRepository;
            }

            public async Task<IDataResult<List<UserStaffDto>>> Handle(GetUsersByCompanyIdQuery request, CancellationToken cancellationToken)
            {
                var users = _companyStaffReadRepository.GetWhere(w => w.CompanyId == Guid.Parse(request.CompanyId))
                .Select(j => new UserStaffDto()
                {
                    User = new UserDto
                    {
                        Id = j.UserId.ToString(),
                        Image = j.User.Image,
                        Email = j.User.Email,
                        NameSurname =j.User.NameSurname
                    },
                    Title = j.Title
                }).ToList();

                return new SuccessDataResult<List<UserStaffDto>>(data: users, "successfully");
            }
        }

    }
}
