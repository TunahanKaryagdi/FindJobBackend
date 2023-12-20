using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Persistence.Repositories
{
    public class JobReadRepository : ReadRepository<Job>, IJobReadRepository
    {
        public JobReadRepository(FindJobDbContext context) : base(context)
        {
        }

        public async Task<Job?> ReadWithNavigations(string id)
        {
            return await Table.Where(j => j.Id == Guid.Parse(id))
                .Include(j=> j.Company)
                .Include(j=>j.Qualifications)
                .Include(j=>j.User).FirstOrDefaultAsync();
        }
    }
}
