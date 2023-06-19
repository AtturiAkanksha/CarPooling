using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Data.DataModels
{
    [Table("BookRides")]
    public class BookRide
    {
        [Key]
        [Column("BookRideId")]
        public Guid BookRideId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("UserName")]
        public string UserName { get; set; } = null!;
        [Column("OfferRideId")]
        public Guid OfferRideId { get; set; } 
        [Column("StartPoint")]
        [Required]
        public string StartPoint { get; set; } = null!;
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
        public int Seats { get; set; }
        [Column("Price")]
        public string Price { get; set; } = null!;
    }
}
