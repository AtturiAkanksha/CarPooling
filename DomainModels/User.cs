﻿using System.ComponentModel.DataAnnotations;

namespace CarPooling.DomainModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
