using System;
using System.Collections.Generic;
using Domain.Bank;
using Domain.Manager;
using Domain.Shared;
using Infrastructure.EFCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IIdentity bankId;
            using (var uow = new EFCoreUnitOfWork())
            {
                var manager = Manager.Create(uow.Repository.NextIdentity(), "First Last");
                var bank = Bank.Create(uow.Repository.NextIdentity(), "123 Street", manager, new List<Atm>());
                bankId = bank.Id;
            }

            IIdentity atmId;
            using (var uow = new EFCoreUnitOfWork())
            {
                var createdBank = uow.Repository.GetBankById(bankId);
                var atm = createdBank.NewAtmInstalled(uow.Repository.NextIdentity(), 5000);
                atmId = atm.Id;
            }

            using (var uow = new EFCoreUnitOfWork())
            {
                var bank = uow.Repository.GetBankById(bankId);
                bank.AtmBalanceChanged(atmId, -1000);

                var updatedBank = uow.Repository.GetBankById(bankId);
            }

            Console.ReadKey();
        }
    }
}
