using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class ApplicationReadRepository : ReadRepository<FindJob.Domain.Entities.Application>, IApplicationReadRepository
    {
        public ApplicationReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
