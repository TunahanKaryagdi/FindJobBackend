using FindJob.Application.Repositories.Application;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class ApplicationWriteRepository : WriteRepository<FindJob.Domain.Entities.Application>, IApplicationWriteRepository
    {
        public ApplicationWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
