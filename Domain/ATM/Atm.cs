using System;

namespace Domain.ATM
{
    public partial class Atm
    {
        public int Id { get; protected set; }
        public double CashBalance { get; protected set; }

        public static Atm Create(double cashBalance)
        {
            return new Atm(null, cashBalance);
        }

        public Atm(int? id, double cashBalance)
        {
            Id = id;
            CashBalance = cashBalance;
        }

        internal void ChangeCashBalance(double amount)
        {
            CashBalance += amount;

            DomainEvents.OnCashBalanceChanged(this);
        }

        public void SetCashBalance(double amount)
        {
            if (amount < 0)
                throw new Exception("Cannot set to a negative amount");

            CashBalance = amount;

            DomainEvents.OnCashBalanceChanged(this);
        }
    }
}
