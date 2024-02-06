using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories.WorkingUser
{
    public class WorkingUserWriteRepository : WriteRepository<Domain.Entities.WorkingUser>, IWorkingUserWriteRepository
    {
        public WorkingUserWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
