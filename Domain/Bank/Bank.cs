using System;
using System.Collections.Generic;
using Domain.Bank.EventArgs;
using Domain.Shared;

namespace Domain.Bank
{
    public class Bank : IAggregateRoot
    {
        public IIdentity Id { get; private set; }
        public string Address { get; private set; }
        public Manager.Manager Manager { get; private set; }
        public IEnumerable<Atm> AtmList { get; private set; }

        public Bank(IIdentity id, string address, Manager.Manager manager, List<Atm> atmList)
        {
            // validate instance
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            if (manager == null) throw new ArgumentNullException(nameof(manager));
            if (atmList == null) throw new ArgumentNullException(nameof(atmList));

            // set properties
            Id = id;
            Address = address;
            Manager = manager;
            AtmList = atmList;
        }

        public static Bank Create(IIdentity id, string address, Manager.Manager manager, List<Atm> atmList)
        {
            var bank = new Bank(id, address, manager, atmList);

            DomainEvent.OnPublished(new OnBankCreatedEventArgs(bank));

            return bank;
        }

        public void AtmBalanceChanged(Atm atm, double cashBalance)
        {
            atm.ChangeCashBalance(cashBalance);

            DomainEvent.OnPublished(new OnCashBalanceChangedEventArgs(this, atm));
        }
    }
}
