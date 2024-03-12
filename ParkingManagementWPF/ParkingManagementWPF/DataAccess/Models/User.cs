using System;
using System.Collections.Generic;

namespace _DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
