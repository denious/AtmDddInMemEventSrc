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
            return atm;
        }

        public void Add(Atm atm)
        {
            // DB create call
        }

        public void Update(Atm atm)
        {
            // DB update call
        }
    }
}
