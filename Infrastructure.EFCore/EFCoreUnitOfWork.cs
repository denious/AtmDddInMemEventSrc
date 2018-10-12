using System;
using Domain;
using Domain.ATM;
using Domain.Shared;

namespace Infrastructure.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        public IAtmRepository AtmRepository { get; }
        public AtmDomainService AtmDomainService { get; }

        private readonly IMailService _mailService;
        private readonly AtmContext _atmContext;

        public EFCoreUnitOfWork(IMailService mailService)
        {
            // save external service references
            _mailService = mailService;

            // load EF context
            _atmContext = new AtmContext();
            _atmContext.Database.EnsureCreated();

            // prepare repositories
            AtmRepository = new AtmRepository(_atmContext);
            AtmDomainService = new AtmDomainService();

            // subscribe to events
            DomainEvents.CashBalanceChanged += AtmOnCashBalanceChangedAsync;
        }

        private async void AtmOnCashBalanceChangedAsync(object sender, EventArgs a)
        {
            var atm = (Atm) sender;

            // send new ATM state to repository
            await AtmRepository.UpdateAsync(atm);

            // notify of new balance
            _mailService.SendBalanceNotification(atm.Id, atm.CashBalance);
        }

        public void Dispose()
        {
            // dispose of EF context
            _atmContext.Dispose();

            // unsubscribe from events
            DomainEvents.CashBalanceChanged -= AtmOnCashBalanceChangedAsync;
        }
    }
}
