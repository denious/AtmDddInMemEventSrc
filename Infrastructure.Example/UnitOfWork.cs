using System;
using Domain;
using Domain.ATM;
using Domain.Shared;

namespace Infrastructure.Example
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAtmRepository AtmRepository { get; }
        public AtmDomainService AtmDomainService { get; }

        private readonly IMailService _mailService;

        public UnitOfWork()
        {
            // prepare repositories
            AtmRepository = new AtmRepository();
            AtmDomainService = new AtmDomainService(AtmRepository);
            _mailService = new MailService();

            // subscribe to events
            Events.CashBalanceChanged += AtmOnCashBalanceChanged;
        }

        private void AtmOnCashBalanceChanged(object sender, EventArgs a)
        {
            var atm = (Atm) sender;

            // send new ATM state to repository
            AtmRepository.Update(atm);

            // notify of new balance
            _mailService.SendBalanceNotification(atm.CashBalance);
        }

        public void Dispose()
        {
            // unsubscribe from events
            Events.CashBalanceChanged -= AtmOnCashBalanceChanged;
        }
    }
}
