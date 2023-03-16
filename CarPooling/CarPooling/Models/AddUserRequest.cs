namespace CarPooling.Models
{
    public class AddUserRequest
    {
        public string fullName { get; set; } = null!;

        public string email { get; set; } = null!;

        public string password { get; set; } = null!;
    }
}
