using System;
using System.Collections.Generic;
using System.Text;
using Domain.Shared;

namespace Domain.ATM
{
    public interface IAtmRepository : IRepository
    {
        Atm GetById(int id);
        void Add(Atm atm);
        void Update(Atm atm);
    }
}
