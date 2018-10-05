using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ATM
{
    public class AtmDomainService
    {
        private readonly IAtmRepository _atmRepository;

        public AtmDomainService(IAtmRepository atmRepository)
        {
            _atmRepository = atmRepository;
        }

        public void WithdrawCash(Atm atm, double amount)
        {
            if (amount <= 0)
                throw new Exception("Cannot withdraw a zero or negative amount");

            if (atm.CashBalance < amount)
                throw new Exception("Not enough cash in ATM");

            atm.ChangeCashBalance(-amount);
        }
    }
}
