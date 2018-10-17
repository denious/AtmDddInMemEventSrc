using Domain;
using Domain.Bank.EventArgs;
using Domain.Manager.EventArgs;
using Domain.Shared;
using Infrastructure.EFCore.EventHandlers;

namespace Infrastructure.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        public IRepository Repository { get; }

        private readonly DbContext _dbContext;

        public EFCoreUnitOfWork()
        {
            // load EF context
            _dbContext = new DbContext();

            // create repository reference
            Repository = new Repository(_dbContext);

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

        public void Dispose()
        {
            // dispose of EF context
            _dbContext.Dispose();

            // unsubscribe from events
            DomainEvent.Published -= DomainEventPublished;
        }
    }
}
