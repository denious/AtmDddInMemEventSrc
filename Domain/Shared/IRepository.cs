namespace Domain.Shared
{
    public interface IRepository
    {
        IIdentity NextIdentity();
        Bank.Bank GetBankById(IIdentity bankId);
        Manager.Manager GetManagerById(IIdentity managerId);
    }
}
