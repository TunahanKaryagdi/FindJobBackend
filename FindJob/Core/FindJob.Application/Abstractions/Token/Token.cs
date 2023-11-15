using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Abstractions.Token
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
