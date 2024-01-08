using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
