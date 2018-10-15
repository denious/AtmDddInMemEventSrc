using System;

namespace Domain
{
    public static class DomainEvent
    {
        internal static void OnPublished(DomainEventArgs args)
        {
            Published?.Invoke(null, args);
        }

        public static event DomainEventHandler Published;
        public delegate void DomainEventHandler(object sender, DomainEventArgs args);
    }

    public abstract class DomainEventArgs : EventArgs
    {
    }
}
