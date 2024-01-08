using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class QualificationReadRepository : ReadRepository<Qualification>, IQualificationReadRepository
    {
        public QualificationReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
