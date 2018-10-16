using System;

namespace Domain.Bank
{
    public class BankDomainService
    {
        public static void WithdrawCashFromAtm(Atm atm, double amount)
        {
            if (amount <= 0)
                throw new Exception("Cannot withdraw a zero or negative amount");

            if (atm.CashBalance < amount)
                throw new Exception("Not enough cash in ATM");

            atm.AddCash(-amount);
        }
    }
}
