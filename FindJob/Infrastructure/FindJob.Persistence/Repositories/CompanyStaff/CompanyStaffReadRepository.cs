using FindJob.Application.Repositories;
using FindJob.Domain.Entities;
using FindJob.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Repositories.WorkingUser
{
    public class CompanyStaffReadRepository : ReadRepository<Domain.Entities.CompanyStaff>, ICompanyStaffReadRepository
    {
        public CompanyStaffReadRepository(FindJobDbContext context) : base(context)
        {
        }


    }
}
