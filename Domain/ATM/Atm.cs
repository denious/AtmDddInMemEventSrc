using System;

namespace Domain
{
    public partial class Atm
    {
        public double CashBalance { get; private set; }

        public Atm(double cashBalance)
        {
            CashBalance = cashBalance;
        }

        internal void ChangeCashBalance(double amount)
        {
            CashBalance += amount;

            OnCashBalanceChanged(this);
        }

        public void SetCashBalance(double amount)
        {
            if (amount < 0)
                throw new Exception("Cannot set to a negative amount");

            CashBalance = amount;

            OnCashBalanceChanged(this);
        }
    }
}
