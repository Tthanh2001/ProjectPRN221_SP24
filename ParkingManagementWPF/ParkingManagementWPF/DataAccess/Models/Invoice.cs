using System;
using System.Collections.Generic;

namespace _DataAccess.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckInOut { get; set; }
        public string VehicleCode { get; set; } = null!;
        public string LotId { get; set; } = null!;
        public decimal? TotalPaid { get; set; }

        public virtual Lot Lot { get; set; } = null!;
        public virtual Vehicle VehicleCodeNavigation { get; set; } = null!;
    }
}
