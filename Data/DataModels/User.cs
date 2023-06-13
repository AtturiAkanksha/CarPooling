using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Data.DataModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Email { get; set; } = null!;
        [Column("Password")]
        public string Password { get; set; } = null!;
    }
}