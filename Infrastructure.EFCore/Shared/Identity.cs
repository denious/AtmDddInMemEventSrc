using System;
using Domain.Shared;

namespace Infrastructure.EFCore.Shared
{
    class Identity : IIdentity
    {
        internal Guid Id { get; }

        internal Identity(Guid id)
        {
            Id = id;
        }

        protected bool Equals(Identity other)
        {
            return Id.Equals(other.Id);
        }

        public bool Equals(IIdentity other)
        {
            if (other is Identity identity)
                return Equals(identity);

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
