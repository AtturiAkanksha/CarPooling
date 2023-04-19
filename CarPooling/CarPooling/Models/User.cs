namespace CarPooling.Models;

public partial class User
{
    public Guid id { get; set; }
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
}
