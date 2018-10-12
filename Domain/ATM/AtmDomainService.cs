using System;

namespace Domain.ATM
{
    public class AtmDomainService
    {
        public static void WithdrawCash(Atm atm, double amount)
        {
            if (amount <= 0)
                throw new Exception("Cannot withdraw a zero or negative amount");

            if (atm.CashBalance < amount)
                throw new Exception("Not enough cash in ATM");

            atm.ChangeCashBalance(-amount);
        }
    }
}
