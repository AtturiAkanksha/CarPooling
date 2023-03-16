using System;
using System.Collections.Generic;
using CarPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Data;

public partial class CarPoolingDbContext : DbContext
{
    public CarPoolingDbContext()
    {
    }

    public CarPoolingDbContext(DbContextOptions<CarPoolingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ride> Rides { get; set; }

    public virtual DbSet<User> Users { get; set; }
}