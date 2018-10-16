using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.EFCore.Shared;

namespace Infrastructure.EFCore.Entities
{
    class BankDTO
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        [ForeignKey("ManagerId")]
        public ManagerDTO Manager { get; set; }
        public Guid ManagerId { get; set; }

        [InverseProperty("Bank")]
        public List<AtmDTO> Atms { get; set; }
    }
}
