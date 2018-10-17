using System;
using System.Linq;
using Domain.Bank;
using Domain.Manager;
using Domain.Shared;
using Infrastructure.EFCore.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;

        internal Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IIdentity NextIdentity()
        {
            return new Identity(Guid.NewGuid());
        }

        public Bank GetBankById(IIdentity bankId)
        {
            var bankDto = _dbContext.Banks
                .Include(o => o.Manager)
                .Include(o => o.Atms)
                .AsNoTracking()
                .First(o => o.Id == ((Identity)bankId).Id);

            var manager = new Manager(new Identity(bankDto.Manager.Id), bankDto.Manager.Name);
            var atms = bankDto.Atms.Select(o => new Atm(new Identity(o.Id), o.CashBalance)).ToList();
            var bank = new Bank(new Identity(bankDto.Id), bankDto.Address, manager, atms);

            return bank;
        }

        public Manager GetManagerById(IIdentity managerId)
        {
            var managerDto = _dbContext.Managers
                .AsNoTracking()
                .First(o => o.Id == ((Identity)managerId).Id);

            var manager = new Manager(new Identity(managerDto.Id), managerDto.Name);

            return manager;
        }
    }
}
