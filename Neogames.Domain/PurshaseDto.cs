using System;
using System.Collections.Generic;
using System.Text;

namespace Neogames.Domain
{
    public class PurchaseDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
