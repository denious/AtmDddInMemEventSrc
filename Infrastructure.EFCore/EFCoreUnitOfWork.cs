using System;
using System.Linq;
using Domain;
using Domain.Bank;
using Domain.Bank.EventArgs;
using Domain.Manager;
using Domain.Manager.EventArgs;
using Domain.Shared;
using Infrastructure.EFCore.EventHandlers;
using Infrastructure.EFCore.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public EFCoreUnitOfWork()
        {
            // load EF context
            _dbContext = new DbContext();

            // subscribe to events
            DomainEvent.Published += DomainEventPublished;
        }

        private void DomainEventPublished(object sender, DomainEventArgs e)
        {
            switch (e)
            {
                case OnBankCreatedEventArgs args:
                {
                    OnBankCreated.Handle(_dbContext, args);
                    break;
                }
                case OnManagerCreatedEventArgs args:
                {
                    OnManagerCreated.Handle(_dbContext, args);
                    break;
                }
                case OnAtmCreatedEventArgs args:
                {
                    OnAtmCreated.Handle(_dbContext, args);
                    break;
                }
                case OnCashBalanceChangedEventArgs args:
                {
                    OnCashBalanceChanged.Handle(_dbContext, args);
                    break;
                }
            }
        }

        public IIdentity NextIdentity()
        {
            return new Identity(Guid.NewGuid());
        }

        public void Dispose()
        {
            // dispose of EF context
            _dbContext.Dispose();

            // unsubscribe from events
            DomainEvent.Published -= DomainEventPublished;
        }

        public Bank GetBankById(IIdentity bankId)
        {
            var bankDto = _dbContext.Banks
                .Include(o => o.Manager)
                .Include(o => o.Atms)
                .AsNoTracking()
                .First(o => o.Id == ((Identity) bankId).Id);

            var manager = new Manager(new Identity(bankDto.Manager.Id), bankDto.Manager.Name);
            var atms = bankDto.Atms.Select(o => new Atm(new Identity(o.Id), o.CashBalance)).ToList();
            var bank = new Bank(new Identity(bankDto.Id), bankDto.Address, manager, atms);

            return bank;
        }
    }
}
