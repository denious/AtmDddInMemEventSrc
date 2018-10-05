using System;
using Domain;
using Domain.ATM;

namespace Infrastructure.Example
{
    class AtmRepository : IAtmRepository
    {
        public Atm GetById(int id)
        {
            var atm = new Atm(0);
            atm.CashBalanceChanged += AtmOnCashBalanceChanged;

            return atm;
        }

        public void Add(Atm atm)
        {
            // DB create call
        }

        private void AtmOnCashBalanceChanged(object sender, Atm.AtmEventArgs a)
        {
            Update(a.Atm);
        }

        public void Update(Atm atm)
        {
            // DB update call
        }
    }
}
