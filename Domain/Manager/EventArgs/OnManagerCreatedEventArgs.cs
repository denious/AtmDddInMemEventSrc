namespace Domain.Manager.EventArgs
{
    public class OnManagerCreatedEventArgs : DomainEventArgs
    {
        public Manager Manager { get; private set; }

        internal OnManagerCreatedEventArgs(Manager manager)
        {
            Manager = manager;
        }
    }
}
