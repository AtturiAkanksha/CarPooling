using CarPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Data;

public class CarPoolingDbContext : DbContext
{
    public CarPoolingDbContext()
    {
    }

    public CarPoolingDbContext(DbContextOptions<CarPoolingDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<OfferRide> OfferedRides { get; set; }
    public virtual DbSet<BookRide> BookedRides { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
}
