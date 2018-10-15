using System;
using System.Collections.Generic;
using Domain.Bank;
using Domain.Manager;
using Infrastructure.EFCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new EFCoreUnitOfWork())
            {
                var manager = Manager.Create(uow.NextIdentity(), "First Last");
                var bank = Bank.Create(uow.NextIdentity(), "123 Street", manager, new List<Atm>());
            }

            Console.ReadKey();
        }
    }
}
