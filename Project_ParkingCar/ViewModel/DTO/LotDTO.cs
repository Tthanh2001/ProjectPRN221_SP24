using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class LotDTO
    {
        public LotDTO()
        {
            Invoices = new HashSet<InvoiceDTO>();
        }

        public string LotArea { get; set; }
        public int LotPosition { get; set; }
        public int TypeId { get; set; }
        public bool? Status { get; set; }
        public string isEmpty { get; set; }
        public string ParkingVehicle { get; set; } = string.Empty;
        public virtual VehicleTypeDTO Type { get; set; } = null!;
        public virtual ICollection<InvoiceDTO> Invoices { get; set; }
    }
}
