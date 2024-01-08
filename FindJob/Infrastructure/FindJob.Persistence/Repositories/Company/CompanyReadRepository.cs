using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
