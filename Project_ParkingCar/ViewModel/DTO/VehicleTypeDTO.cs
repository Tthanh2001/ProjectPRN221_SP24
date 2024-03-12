using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class VehicleTypeDTO
    {
        public VehicleTypeDTO()
        {
        }

        public int TypeId { get; set; }
        public string? Name { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal PricePerYear { get; set; }
    }
}
