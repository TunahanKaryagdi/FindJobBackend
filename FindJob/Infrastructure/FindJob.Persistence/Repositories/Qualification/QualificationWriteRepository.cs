using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories
{
    public class QualificationWriteRepository : WriteRepository<Qualification>, IQualificationWriteRepository
    {
        public QualificationWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
