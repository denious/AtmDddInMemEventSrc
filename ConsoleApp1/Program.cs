using System;
using Infrastructure.EFCore;
using Infrastructure.MailService.SendGrid;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = new SendGridMailService();
            using (var uow = new EFCoreUnitOfWork(mailService))
            {
                var atm = uow.AtmRepository.GetById(1);
                Console.WriteLine("ATM balance: $" + atm.CashBalance);

                Console.WriteLine("Setting balance to $1000");
                atm.SetCashBalance(1000);
                Console.WriteLine("ATM balance: $" + atm.CashBalance);

                try
                {
                    Console.WriteLine("Trying to withdraw $2000");
                    uow.AtmDomainService.WithdrawCash(atm, 2000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Trying to withdraw $1000");
                uow.AtmDomainService.WithdrawCash(atm, 1000);

                Console.WriteLine("New balance: $" + atm.CashBalance);
            }

            Console.ReadKey();
        }
    }
}
