using CarPooling.Services.Contracts;
using Carpooling.DomainModels;
using Carpooling.Data.IRepository;

namespace CarPooling.Services
{
    public class BookRideService : IBookRideService
    {
        private readonly IBookRideRepository _bookRideRepository;

        public BookRideService(IBookRideRepository bookRideRepository)
        {
            this._bookRideRepository = bookRideRepository;
        }

        public IEnumerable<BookRide> GetBookedRides()
        {
            return this._bookRideRepository.GetBookedRides();

        }

        public async Task<BookRide> BookRide(BookRide bookRideRequest)
        {
            return await this._bookRideRepository.BookRide(bookRideRequest);
        }
    }
}
