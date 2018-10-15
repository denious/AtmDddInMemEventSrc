using Domain.Shared;

namespace Queries.Shared
{
    class Identity : IIdentity
    {
        private int Id { get; }

        internal Identity(int id)
        {
            Id = id;
        }
    }
}
