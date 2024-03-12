using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ViewModel.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Vehicles = new HashSet<VehicleDTO>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<VehicleDTO> Vehicles { get; set; }
    }
}
