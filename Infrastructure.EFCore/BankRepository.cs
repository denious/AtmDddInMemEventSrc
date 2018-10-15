using System.Threading.Tasks;
using Domain.Bank;
using Domain.Shared;

namespace Infrastructure.EFCore
{
    class BankRepository : IBankRepository
    {
        private readonly DbContext _dbContext;

        public BankRepository(DbContext context)
        {
            _dbContext = context;
        }

        public Task<Bank> GetByIdAsync(IIdentity id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddBankAsync(Bank bank)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateBankAsync(Bank bank)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteBankAsync(Bank bank)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAtmAsync(Atm atm)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAtmAsync(Atm atm)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAtmAsync(Atm atm)
        {
            throw new System.NotImplementedException();
        }
    }
}
