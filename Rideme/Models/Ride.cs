namespace Rideme.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Tripprice { get; set; }
        public string Paymentstatus { get; set; } //pending,paid
        public string Ridestatus { get; set; } //pending, accepted, rejected,completed, not completed

        public Passenger Passenger { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }

}