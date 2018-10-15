using System;
using Domain.Manager.EventArgs;
using Domain.Shared;

namespace Domain.Manager
{
    public class Manager : IAggregateRoot
    {
        public IIdentity Id { get; private set; }
        public string Name { get; private set; }

        public Manager(IIdentity id, string name)
        {
            // validate instance
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            
            // set properties
            Id = id;
            Name = name;
        }

        public static Manager Create(IIdentity id, string name)
        {
            var manager = new Manager(id, name);

            DomainEvent.OnPublished(new OnManagerCreatedEventArgs(manager));

            return manager;
        }
    }
}
