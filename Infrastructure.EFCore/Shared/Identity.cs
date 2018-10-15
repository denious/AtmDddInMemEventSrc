using System;
using Domain.Shared;

namespace Infrastructure.EFCore.Shared
{
    class Identity : IIdentity
    {
        private Guid Id { get; }

        internal Identity(Guid id)
        {
            Id = id;
        }
    }
}
