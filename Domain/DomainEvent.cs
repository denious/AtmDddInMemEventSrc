using System;

namespace Domain
{
    public static class DomainEvent
    {
        internal static void OnPublished(DomainEventArgs args)
        {
            if (Published == null)
                throw new NotImplementedException("No one has subscribed to this event.");

            Published.Invoke(null, args);
        }

        public static event DomainEventHandler Published;
        public delegate void DomainEventHandler(object sender, DomainEventArgs args);
    }

    public abstract class DomainEventArgs : EventArgs
    {
    }
}
