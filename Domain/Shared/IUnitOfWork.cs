using System;

namespace Domain.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }
    }
}
