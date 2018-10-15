using System.Threading.Tasks;
using Domain.Manager;
using Domain.Shared;

namespace Infrastructure.EFCore
{
    class ManagerRepository : IManagerRepository
    {
        private readonly DbContext _dbContext;

        public ManagerRepository(DbContext context)
        {
            _dbContext = context;
        }

        public Task<Manager> GetByIdAsync(IIdentity id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Manager manager)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Manager manager)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Manager manager)
        {
            throw new System.NotImplementedException();
        }
    }
}
