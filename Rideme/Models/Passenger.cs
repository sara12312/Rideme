namespace Rideme.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Ride> Rides { get; set; } = new List<Ride>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
