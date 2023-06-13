using Carpooling.DomainModels;

namespace Carpooling.Data.IRepository
{
    public interface IBookRideRepository
    {
        public IEnumerable<BookRide> GetBookedRides();
        Task<BookRide> BookRide(BookRide bookRide);

    }
}
