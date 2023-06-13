using Carpooling.DomainModels;

namespace CarPooling.Services.Contracts
{
    public interface IBookRideService
    {
        public IEnumerable<BookRide> GetBookedRides();
        Task<BookRide> BookRide(BookRide bookRideRequest);

    }
}
