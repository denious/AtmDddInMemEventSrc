using System;
using Domain;
using Domain.Bank;
using Domain.Bank.EventArgs;
using Domain.Manager;
using Domain.Shared;
using Infrastructure.EFCore.Shared;

namespace Infrastructure.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        public IBankRepository BankRepository { get; }
        public BankDomainService BankDomainService { get; }
        public IManagerRepository ManagerRepository { get; }

        private readonly DbContext _dbContext;

        public EFCoreUnitOfWork()
        {
            // load EF context
            _dbContext = new DbContext();
            _dbContext.Database.EnsureCreated();

            // prepare repositories
            BankRepository = new BankRepository(_dbContext);
            BankDomainService = new BankDomainService();
            ManagerRepository = new ManagerRepository(_dbContext);

            // subscribe to events
            DomainEvent.Published += DomainEventPublished;
        }

        private void DomainEventPublished(object sender, DomainEventArgs e)
        {
            switch (e)
            {
                case OnBankCreatedEventArgs bankCreatedEventArgs:
                {
                    BankRepository.AddBankAsync(bankCreatedEventArgs.Bank).GetAwaiter().GetResult();
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
    }
}
