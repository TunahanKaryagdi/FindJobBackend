using FindJob.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Contexts
{
    public class FindJobDbContext : DbContext
    {
        public FindJobDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Job> Jobs {  get; set; }        
        
    }
}
