using System.ComponentModel.DataAnnotations;

namespace Carpooling.DomainModels
{
    public class OfferRide
    {
        public Guid OfferRideId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string StartPoint { get; set; } = null!;
        public string? Stops { get; set; }
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
        public int Seats { get; set; } = 0;
        public string Price { get; set; } = null!;
    }
}

