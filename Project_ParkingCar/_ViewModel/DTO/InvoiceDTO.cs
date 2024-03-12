using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckInOut { get; set; }
        public string VehicleCode { get; set; } = null!;
        public string LotId { get; set; } = null!;
        public decimal? TotalPaid { get; set; }
    }
}
