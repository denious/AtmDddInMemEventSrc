using System;
using System.Collections.Generic;
using System.Text;
using Domain.ATM;

namespace Infrastructure.EFCore.Entities
{
    class AtmDto
    {
        public int ATM_ID { get; set; }
        public double CASH_BALANCE { get; set; }
    }
}
