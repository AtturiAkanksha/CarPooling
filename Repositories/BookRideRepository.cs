using CarPooling.Data;
using CarPooling.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Repositories
{
    public class BookRideRepository
    {
        private readonly CarPoolingDbContext dbContext;

        public BookRideRepository(CarPoolingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BookRide>> GetBookedRides()
        {
            List<BookRide> bookedRides = await dbContext.BookedRides.ToListAsync();
            return bookedRides;
        }

        public async Task<BookRide> BookRide(BookRide bookRide)
        {
            var offeredRide = dbContext.OfferedRides.FirstOrDefault(x =>
             x.StartPoint == bookRide.StartPoint &&
             x.EndPoint == bookRide.EndPoint &&
             x.TimeSlot == bookRide.TimeSlot &&
             x.Date == bookRide.Date &&
             x.Seats >= bookRide.Seats
           );
            try
            {
                if (offeredRide != null)
                {
                    await dbContext.BookedRides.AddAsync(bookRide);
                    await dbContext.SaveChangesAsync();
                    return bookRide;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
