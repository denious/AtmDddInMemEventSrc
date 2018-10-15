namespace Domain.Bank.EventArgs
{
    public class OnCashBalanceChangedEventArgs : DomainEventArgs
    {
        public Bank Bank { get; private set; }
        public Atm Atm { get; private set; }

        internal OnCashBalanceChangedEventArgs(Bank bank, Atm atm)
        {
            Bank = bank;
            Atm = atm;
        }
    }
}
