using System;
using Domain.ATM;

namespace Domain.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IAtmRepository AtmRepository { get; }
        AtmDomainService AtmDomainService { get; }
    }
}
