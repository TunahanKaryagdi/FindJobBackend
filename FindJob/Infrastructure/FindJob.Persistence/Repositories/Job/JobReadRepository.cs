using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories
{
    internal class JobReadRepository : ReadRepository<Job>, IJobReadRepository
    {
        public JobReadRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
