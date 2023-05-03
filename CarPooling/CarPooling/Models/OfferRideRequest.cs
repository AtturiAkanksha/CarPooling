namespace CarPooling.Models
{
    public class OfferRideRequest
    {
        public string UserId { get; set; } =null!;
        public string UserName { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public  List<Location>?  stops { get; set; }
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
        public int Seats { get; set; } = 0;
        public string Price { get; set; } = null!;
        public bool IsActive { get; set; }=false;
    }
}
