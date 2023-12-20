using FindJob.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
