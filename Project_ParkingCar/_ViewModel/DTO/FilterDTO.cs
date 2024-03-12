using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class FilterDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string VehicleCode { get; set; } = null!;
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckInOut { get; set; }
    }
}
