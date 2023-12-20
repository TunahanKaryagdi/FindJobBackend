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
    public class QualificationWriteRepository : WriteRepository<Qualification>, IQualificationWriteRepository 
    {
        public QualificationWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
