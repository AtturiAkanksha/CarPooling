using System.ComponentModel.DataAnnotations;

namespace Carpooling.DomainModels
{
    public class BookRide
    {
        public Guid BookRideId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string OfferRideId { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
        public int Seats { get; set; }
        public string Price { get; set; } = null!;
    }
}