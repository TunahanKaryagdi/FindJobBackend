using FindJob.Application.Repositories.PreferredLocation;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class PreferredLocationReadRepository : ReadRepository<Domain.Entities.PreferredLocation>, IPreferredLocationReadRepository
    {
        public PreferredLocationReadRepository(FindJobDbContext context) : base(context)
        {
        }


    }
}
