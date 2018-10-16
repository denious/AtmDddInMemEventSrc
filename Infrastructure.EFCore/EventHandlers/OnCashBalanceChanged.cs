using Domain.Bank.EventArgs;
using Infrastructure.EFCore.Entities;

namespace Infrastructure.EFCore.EventHandlers
{
    static class OnCashBalanceChanged
    {
        internal static void Handle(DbContext dbContext, OnCashBalanceChangedEventArgs args)
        {
            var atmDTO = new AtmDTO
            {
                Id = ((Shared.Identity) args.Atm.Id).Id,
            };

            dbContext.Atms.Attach(atmDTO);
            atmDTO.CashBalance = args.Atm.CashBalance;
            
            dbContext.SaveChanges();
        }
    }
}
