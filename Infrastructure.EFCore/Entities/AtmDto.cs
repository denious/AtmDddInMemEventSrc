using Infrastructure.EFCore.Shared;

namespace Infrastructure.EFCore.Entities
{
    class AtmDTO
    {
        public Identity ATM_ID { get; set; }
        public double CASH_BALANCE { get; set; }
    }
}
