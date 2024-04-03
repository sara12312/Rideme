using Rideme.Models;

namespace Rideme.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } //admin ,passenger,driver
        public bool Isactive { get; set; } = false; //default is false when a user registers
        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }

    }
}
