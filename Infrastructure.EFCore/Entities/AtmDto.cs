using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EFCore.Entities
{
    class AtmDTO
    {
        public Guid Id { get; set; }
        public double CashBalance { get; set; }

        [ForeignKey("BankId")]
        public BankDTO Bank { get; set; }
        public Guid BankId { get; set; }
    }
}
