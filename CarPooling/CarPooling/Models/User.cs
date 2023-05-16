namespace CarPooling.Models;

public partial class User
{
    public int id { get; set=0; }
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
}
