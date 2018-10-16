using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Bank.EventArgs;
using Domain.Shared;

namespace Domain.Bank
{
    public class Bank : IAggregateRoot
    {
        public IIdentity Id { get; private set; }
        public string Address { get; private set; }
        public Manager.Manager Manager { get; private set; }

        private readonly List<Atm> _atms;
        public IEnumerable<Atm> Atms => _atms;

        public Bank(IIdentity id, string address, Manager.Manager manager, List<Atm> atms)
        {
            // validate instance
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            if (manager == null) throw new ArgumentNullException(nameof(manager));
            if (atms == null) throw new ArgumentNullException(nameof(atms));

            // set properties
            Id = id;
            Address = address;
            Manager = manager;
            _atms = atms;
        }

        public static Bank Create(IIdentity id, string address, Manager.Manager manager, List<Atm> atmList)
        {
            var bank = new Bank(id, address, manager, atmList);

            DomainEvent.OnPublished(new OnBankCreatedEventArgs(bank));

            return bank;
        }

        public Atm NewAtmInstalled(IIdentity id, double cashBalance)
        {
            var atm = new Atm(id, cashBalance);
            _atms.Add(atm);

            DomainEvent.OnPublished(new OnAtmCreatedEventArgs(atm, Id));

            return atm;
        }

        public void AtmBalanceChanged(IIdentity atmId, double cashBalance)
        {
            var atm = Atms.FirstOrDefault(o => o.Id.Equals(atmId));
            if (atm == null) throw new NullReferenceException();

            atm.AddCash(cashBalance);

            DomainEvent.OnPublished(new OnCashBalanceChangedEventArgs(this, atm));
        }
    }
}
