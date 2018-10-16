using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EFCore.Entities
{
    class ManagerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Manager")]
        public List<BankDTO> Banks { get; set; }
    }
}
