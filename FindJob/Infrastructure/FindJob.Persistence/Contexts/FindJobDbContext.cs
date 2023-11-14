using FindJob.Domain.Entities;
using FindJob.Domain.Entities.Common;
using FindJob.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence.Contexts
{
    public class FindJobDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public FindJobDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Job> Jobs {  get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in data)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.UpdatedDate = DateTime.UtcNow;
                    item.Entity.CreatedDate = DateTime.UtcNow;

                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
