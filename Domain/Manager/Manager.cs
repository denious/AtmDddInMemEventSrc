using System;

namespace Domain.Manager
{
    public class Manager
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public static Manager Create(string name)
        {
            return new Manager(null, name);
        }

        public Manager(int? id, string name)
        {
            // validate instance
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            if (id != null) Id = id.Value;
            
            // set properties
            Name = name;
        }
    }
}
