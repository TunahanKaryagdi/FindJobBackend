using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories.WorkingUser
{
    public class WorkingUserReadRepository : ReadRepository<Domain.Entities.WorkingUser>, IWorkingUserReadRepository
    {
        public WorkingUserReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
