using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Manager
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Task AddAsync(Manager manager);
        Task UpdateAsync(Manager manager);
        Task DeleteAsync(Manager manager);
    }
}
