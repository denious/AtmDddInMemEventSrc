using Domain.Manager.EventArgs;
using Infrastructure.EFCore.Entities;

namespace Infrastructure.EFCore.EventHandlers
{
    static class OnManagerCreated
    {
        internal static void Handle(DbContext dbContext, OnManagerCreatedEventArgs args)
        {
            var managerDTO = new ManagerDTO
            {
                Id = ((Shared.Identity) args.Manager.Id).Id,
                Name = args.Manager.Name
            };

            dbContext.Managers.Add(managerDTO);
            dbContext.SaveChanges();
        }
    }
}
