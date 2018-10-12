using System;
using System.Collections.Generic;
using Domain.ATM;
using Domain.Shared;

namespace Domain.Bank
{
    class Bank : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Address { get; private set; }
        public Manager.Manager Manager { get; private set; }
        public IEnumerable<Atm> AtmList { get; private set; }

        public static Bank Create(string address, Manager.Manager manager)
        {
            return new Bank(null, address, manager, null);
        }

        public Bank(int? id, string address, Manager.Manager manager, List<Atm> atmList)
        {
            // validate instance
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            if (manager == null) throw new ArgumentNullException(nameof(manager));

            if (id != null)
            {
                Id = id.Value;
                if (atmList == null) throw new ArgumentNullException(nameof(atmList));
            }
            else
            {
                AtmList = new Atm[0];
            }

            // set properties
            Address = address;
            Manager = manager;
            AtmList = atmList;
        }
    }
}
