using FindJob.Application.Repositories;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories.WorkingUser
{
    public class CompanyStaffWriteRepository : WriteRepository<Domain.Entities.CompanyStaff>, ICompanyStaffWriteRepository
    {
        public CompanyStaffWriteRepository(FindJobDbContext context) : base(context)
        {
        }
    }
}
