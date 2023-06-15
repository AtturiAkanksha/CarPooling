namespace CarPooling.API.RequestDTOs
{
    public class BookRideRequest
    {
        public string UserName { get; set; } = null!;
        public string OfferRideId { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
        public int Seats { get; set; } = 0;
        public string Price { get; set; } = null!;
    }
}
