using FindJob.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.CompanyStaff.Dtos
{
    public class UserStaffDto
    {
        public UserDto User { get; set; }
        public string Title { get; set; }
    }
}
