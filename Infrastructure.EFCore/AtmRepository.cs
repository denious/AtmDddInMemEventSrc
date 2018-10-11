using System;
using System.Linq;
using Domain;
using Domain.ATM;

namespace Infrastructure.EFCore
{
    class AtmRepository : IAtmRepository
    {
        private readonly AtmContext _atmContext;

        public AtmRepository(AtmContext context)
        {
            _atmContext = context;
        }

        public IQueryable<Atm> Get()
        {
            return _atmContext.Atms;
        }

        public Atm GetById(int id)
        {
            return _atmContext.Atms.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Atm atm)
        {
            _atmContext.Atms.Add(atm);
            _atmContext.SaveChanges();
        }

        public void Update(Atm atm)
        {
            _atmContext.Atms.Update(atm);
            _atmContext.SaveChanges();
        }
    }
}
