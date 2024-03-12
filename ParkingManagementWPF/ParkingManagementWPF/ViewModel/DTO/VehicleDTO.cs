using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class VehicleDTO
    {
        public VehicleDTO()
        {
            Invoices = new HashSet<InvoiceDTO>();
        }

        public string VehicleCode { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public int TypeId { get; set; }
        public bool? IsParking { get; set; }
        public int UserId { get; set; }


        public virtual string TypeName { get; set; } = null!;
        public virtual ICollection<InvoiceDTO> Invoices { get; set; }
    }
}
