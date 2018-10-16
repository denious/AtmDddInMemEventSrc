using Domain.Shared;

namespace Domain.Bank.EventArgs
{
    public class OnAtmCreatedEventArgs : DomainEventArgs
    {
        public IIdentity BankId { get; private set; }
        public Atm Atm { get; private set; }

        internal OnAtmCreatedEventArgs(Atm atm, IIdentity bankId)
        {
            BankId = bankId;
            Atm = atm;
        }
    }
}
