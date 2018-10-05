using Domain.ATM;
using Domain.Shared;

namespace Infrastructure.Example
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAtmRepository AtmRepository { get; }
        public AtmDomainService AtmDomainService { get; }

        public UnitOfWork()
        {
            // prepare repositories
            AtmRepository = new AtmRepository();
            AtmDomainService = new AtmDomainService(AtmRepository);
        }

        public void Dispose()
        {
        }
    }
}
