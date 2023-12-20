using FindJob.Domain.Entities;

namespace FindJob.Application.Repositories
{
    public interface IJobReadRepository : IReadRepository<Job>
    {

        Task<Job?> ReadWithNavigations(string id);

    }
}
