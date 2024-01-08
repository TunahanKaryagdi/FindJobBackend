using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;

namespace FindJob.Persistence.Repositories.Skill
{
    public class SkillReadRepository : ReadRepository<FindJob.Domain.Entities.Skill>, ISkillReadRepository
    {
        public SkillReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
