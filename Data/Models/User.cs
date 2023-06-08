using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CarPooling.Data.Models;

public partial class User
{
    [Key]
    public int id { get; set; }
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
}
