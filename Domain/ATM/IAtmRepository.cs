using System.Linq;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.ATM
{
    public interface IAtmRepository : IRepository
    {
        IQueryable<Atm> Get();
        Task<Atm> GetByIdAsync(int id);
        Task AddAsync(Atm atm);
        Task UpdateAsync(Atm atm);
        Task DeleteAsync(Atm atm);
    }
}
