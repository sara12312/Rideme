namespace Rideme.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int RideId { get; set; } // Foreign key
        public int PassengerId { get; set; } // Foreign key
        public int DriverId { get; set; } // Foreign key
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; } // the feedback

        public Ride Ride { get; set; } // Navigation property
        public Passenger Passenger { get; set; }
        public Driver Driver { get; set; }
    }
}
