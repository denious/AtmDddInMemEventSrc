using System;
using Domain.Shared;

namespace Domain.Bank
{
    public class Atm
    {
        public IIdentity Id { get; protected set; }
        public double CashBalance { get; protected set; }

        public static Atm Create(double cashBalance)
        {
            return new Atm(null, cashBalance);
        }

        public Atm(IIdentity id, double cashBalance)
        {
            Id = id;
            CashBalance = cashBalance;
        }

        internal void ChangeCashBalance(double amount)
        {
            if (amount < 0)
                throw new Exception("Cannot set to a negative amount");

            CashBalance = amount;
        }
    }
}
