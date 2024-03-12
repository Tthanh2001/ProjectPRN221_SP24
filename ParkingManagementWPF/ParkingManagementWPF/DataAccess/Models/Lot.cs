using System;
using System.Collections.Generic;

namespace _DataAccess.Models
{
    public partial class Lot
    {
        public Lot()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string LotId { get; set; } = null!;
        public int TypeId { get; set; }
        public bool? Status { get; set; }

        public virtual VehicleType Type { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
