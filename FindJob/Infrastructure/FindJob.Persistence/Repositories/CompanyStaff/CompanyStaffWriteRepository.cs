using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories.WorkingUser
{
    public class CompanyStaffWriteRepository : WriteRepository<Domain.Entities.CompanyStaff>, ICompanyStaffWriteRepository
    {
        public CompanyStaffWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
