using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories.Skill
{
    public class SkillWriteRepository : WriteRepository<FindJob.Domain.Entities.Skill>, ISkillWriteRepository
    {
        public SkillWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
