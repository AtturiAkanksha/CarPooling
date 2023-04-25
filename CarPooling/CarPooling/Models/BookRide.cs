namespace CarPooling.Models;

public partial class BookRide
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string StartPoint { get; set; } = null!;
    public string EndPoint { get; set; } = null!;
    public string Date { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public int Seats { get; set; } = 0;
}
