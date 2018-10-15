using System;

namespace Domain.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IIdentity NextIdentity();
    }
}
