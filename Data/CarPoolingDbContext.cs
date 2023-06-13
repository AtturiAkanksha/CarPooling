using CarPooling.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Data
{
    public class CarPoolingDbContext : DbContext
    {
        public CarPoolingDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TL599\\SQLEXPRESS;Initial Catalog=carPoolingDb;Integrated " +
                    "Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public CarPoolingDbContext(DbContextOptions<CarPoolingDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OfferRide> OfferedRides { get; set; }
        public virtual DbSet<BookRide> BookedRides { get; set; }
    }
}
