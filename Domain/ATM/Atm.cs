using System;

namespace Domain
{
    public partial class Atm
    {
        public int Id { get; private set; }
        public double CashBalance { get; private set; }

        public static Atm Create(double cashBalance)
        {
            return new Atm(0, cashBalance);
        }

        public Atm(int id, double cashBalance)
        {
            Id = id;
            CashBalance = cashBalance;
        }

        internal void ChangeCashBalance(double amount)
        {
            CashBalance += amount;

            Events.OnCashBalanceChanged(this);
        }

        public void SetCashBalance(double amount)
        {
            if (amount < 0)
                throw new Exception("Cannot set to a negative amount");

            CashBalance = amount;

            Events.OnCashBalanceChanged(this);
        }
    }
}
