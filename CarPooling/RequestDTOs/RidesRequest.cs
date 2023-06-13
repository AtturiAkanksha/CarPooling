namespace CarPooling.API.RequestDTOs
{
    public class RidesRequest
    {
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
    }
}
