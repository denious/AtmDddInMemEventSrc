using Domain.Bank.EventArgs;
using Infrastructure.EFCore.Entities;

namespace Infrastructure.EFCore.EventHandlers
{
    static class OnAtmCreated
    {
        internal static void Handle(DbContext dbContext, OnAtmCreatedEventArgs args)
        {
            var atmDTO = new AtmDTO
            {
                Id = ((Shared.Identity) args.Atm.Id).Id,
                CashBalance = args.Atm.CashBalance,
                BankId = ((Shared.Identity) args.BankId).Id
            };

            dbContext.Atms.Add(atmDTO);
            dbContext.SaveChanges();
        }
    }
}
