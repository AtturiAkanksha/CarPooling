namespace CarPooling.Models
{
    public class BookRideRequest
    {
        public string Name { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public int Seats { get; set; } = 0;
    }
}
