using System;
using System.Collections.Generic;

namespace _DataAccess.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Lots = new HashSet<Lot>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int TypeId { get; set; }
        public string? Name { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal PricePerYear { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
