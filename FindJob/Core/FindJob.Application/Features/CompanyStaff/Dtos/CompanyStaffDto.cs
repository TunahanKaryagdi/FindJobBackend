using FindJob.Application.Features.Company.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.WorkingUser.Dtos
{
    public class CompanyStaffDto
    {
        public CompanyDto Company { get; set; }
        public string Title { get; set; }
    }
}
