using FindJob.Application.Repositories.PreferredLocation;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class PreferredLocationWriteRepository : WriteRepository<Domain.Entities.PreferredLocation>, IPreferredLocationWriteRepository
    {
        public PreferredLocationWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
