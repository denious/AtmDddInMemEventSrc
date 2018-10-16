using System;
using Domain.Shared;

namespace Domain.Bank
{
    public class Atm
    {
        public IIdentity Id { get; protected set; }
        public double CashBalance { get; private set; }

        public Atm(IIdentity id, double cashBalance)
        {
            // validate
            if (cashBalance < 0) throw new ArgumentOutOfRangeException(nameof(cashBalance));

            Id = id;
            CashBalance = cashBalance;
        }

        internal void AddCash(double amount)
        {
            if (CashBalance + amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            CashBalance += amount;
        }
    }
}
