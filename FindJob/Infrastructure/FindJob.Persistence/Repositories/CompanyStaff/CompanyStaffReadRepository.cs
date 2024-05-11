using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class CompanyStaffReadRepository : ReadRepository<Domain.Entities.CompanyStaff>, ICompanyStaffReadRepository
    {
        public CompanyStaffReadRepository(FindJobDbContext context) : base(context)
        {
        }


    }
}
