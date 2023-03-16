using System;
using System.Collections.Generic;

namespace CarPooling.Models;

public partial class User
{
    public Guid id { get; set; }

    public string fullName { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;
}
