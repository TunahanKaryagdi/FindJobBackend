using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Applications.Dtos
{
    public class ApplicationDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public JobDto Job { get; set; }
        public UserDto User{ get; set; }
        public bool Status { get; set; }
    }
}
