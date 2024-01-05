using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories.Skill
{
    public class SkillWriteRepository : WriteRepository<FindJob.Domain.Entities.Skill>, ISkillWriteRepository
    {
        public SkillWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
