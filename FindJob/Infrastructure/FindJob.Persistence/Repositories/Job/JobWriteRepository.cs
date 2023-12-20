using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class JobWriteRepository : WriteRepository<Job>, IJobWriteRepository
    {
        public JobWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
