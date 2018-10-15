using System.Threading.Tasks;

namespace Domain.Shared
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(IIdentity id);
    }
}
