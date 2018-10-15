using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Bank
{
    public interface IBankRepository : IRepository<Bank>
    {
        #region Banks

        Task AddBankAsync(Bank bank);
        Task UpdateBankAsync(Bank bank);
        Task DeleteBankAsync(Bank bank);

        #endregion

        #region Atms

        Task AddAtmAsync(Atm atm);
        Task UpdateAtmAsync(Atm atm);
        Task DeleteAtmAsync(Atm atm);

        #endregion
    }
}
