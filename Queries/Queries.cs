using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Bank;
using Queries.Shared;

namespace Queries
{
    public class Queries:IDisposable
    {
        private DbContext _dbContext;

        public Queries()
        {
            _dbContext = new DbContext();
        }

        public IQueryable<Bank> GetBanks()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
