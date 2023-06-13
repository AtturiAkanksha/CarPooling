using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Data.DataModels
{
    [Table("OfferRides")]
    public class OfferRide
    {
        [Key]
        [Column("OfferRideId")]
        public Guid OfferRideId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("UserName")]
        public string? UserName { get; set; }
        [Column("StartPoint")]
        [Required]
        public string StartPoint { get; set; } = null!;
        [Column("Stops")]
        public string? Stops { get; set; }
        [Column("EndPoint")]
        [Required]
        public string EndPoint { get; set; } = null!;
        [Column("Date")]
        [Required]
        public string Date { get; set; } = null!;
        [Column("TimeSlot")]
        [Required]
        public string TimeSlot { get; set; } = null!;
        [Column("Seats")]
        [Required]
        public int Seats { get; set; } = 0;
        [Column("Price")]
        [Required]
        public string Price { get; set; } = null!;
    }
}

