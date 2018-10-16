using Domain.Bank.EventArgs;
using Infrastructure.EFCore.Entities;

namespace Infrastructure.EFCore.EventHandlers
{
    static class OnBankCreated
    {
        internal static void Handle(DbContext dbContext, OnBankCreatedEventArgs args)
        {
            var bankDto = new BankDTO
            {
                Id = ((Shared.Identity) args.Bank.Id).Id,
                Address = args.Bank.Address,
                ManagerId = ((Shared.Identity) args.Bank.Manager.Id).Id
            };

            dbContext.Banks.Add(bankDto);
            dbContext.SaveChanges();
        }
    }
}
