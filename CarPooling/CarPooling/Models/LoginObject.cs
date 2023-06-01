using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using Microsoft.OpenApi.Any;

namespace CarPooling.Models
{
    public class LoginObject
    {
        public int UserId { get; set; }
        public string  NewToken { get; set; }
    }
}
