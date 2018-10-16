using System;
using System.Linq;
using Bank = Queries.ViewModels.Bank;
using Manager = Queries.ViewModels.Manager;

namespace Queries
{
    public class Queries : IDisposable
    {
        private readonly DbContext _dbContext;

        public Queries()
        {
            _dbContext = new DbContext();
        }

        public IQueryable<Bank> GetBanks()
        {
            return _dbContext.Banks;
        }

        public IQueryable<Bank> GetBankById(Guid id)
        {
            return _dbContext.Banks.Where(o => o.Id == id);
        }

        public IQueryable<Manager> GetManagers()
        {
            return _dbContext.Managers;
        }

        public IQueryable<Manager> GetManagerById(Guid id)
        {
            return _dbContext.Managers.Where(o => o.Id == id);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}