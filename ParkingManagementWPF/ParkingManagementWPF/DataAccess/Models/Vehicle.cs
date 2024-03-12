using System;
using System.Collections.Generic;

namespace _DataAccess.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string VehicleCode { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public bool? IsParking { get; set; }

        public virtual VehicleType Type { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
