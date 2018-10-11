using System;
using System.Linq;
using Domain.Shared;

namespace Domain.ATM
{
    public interface IAtmRepository : IRepository
    {
        IQueryable<Atm> Get();
        Atm GetById(int id);
        void Add(Atm atm);
        void Update(Atm atm);
    }
}
