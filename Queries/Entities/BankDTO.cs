using Queries.Shared;

namespace Queries.Entities
{
    class BankDTO
    {
        public int BANK_ID { get; set; }
        public string ADDRESS { get; set; }
        public Identity MANAGER_ID { get; set; }
    }
}
