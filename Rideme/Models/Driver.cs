namespace Rideme.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }
        public string Cartype { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Issmoking { get; set; }
        public bool Isblocked { get; set; } = false;
        public User User { get; set; }
        public ICollection<Ride> Rides { get; set; } = new List<Ride>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    }
}
