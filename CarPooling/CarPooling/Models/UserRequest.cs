using System.ComponentModel.DataAnnotations;

namespace CarPooling.Models
{
    public class UserRequest

    { 
        public string email { get; set; } = null!;

        public string password { get; set; } = null!;
    }
}
