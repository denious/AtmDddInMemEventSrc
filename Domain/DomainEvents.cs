using System;
using Domain.ATM;

namespace Domain
{
    public static class DomainEvents
    {
        public delegate void EventHandler(object sender, EventArgs eventArgs);

        public static event EventHandler CashBalanceChanged;

        public static void OnCashBalanceChanged(Atm atm)
        {
            var handler = CashBalanceChanged;
            handler?.Invoke(atm, new EventArgs());
        }

        public delegate int EntityAddedEventHandler(object sender, EventArgs eventArgs);
        public static event EntityAddedEventHandler BankAdded;

        public static int OnBankAdded(Bank.Bank bank)
        {
            var handler = BankAdded;
            if (handler == null) throw new ApplicationException("No handler for " + nameof(OnBankAdded));

            return handler.Invoke(bank, new EventArgs());
        }
    }
}
