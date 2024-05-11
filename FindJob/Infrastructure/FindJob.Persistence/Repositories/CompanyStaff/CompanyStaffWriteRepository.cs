using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class CompanyStaffWriteRepository : WriteRepository<Domain.Entities.CompanyStaff>, ICompanyStaffWriteRepository
    {
        public CompanyStaffWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
