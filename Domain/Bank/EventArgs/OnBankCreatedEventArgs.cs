namespace Domain.Bank.EventArgs
{
    public class OnBankCreatedEventArgs : DomainEventArgs
    {
        public Bank Bank { get; private set; }

        internal OnBankCreatedEventArgs(Bank bank)
        {
            Bank = bank;
        }
    }
}
