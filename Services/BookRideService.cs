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
            List<BookRide> getBookedRides = (List<BookRide>)this._bookRideRepository.GetBookedRides();
            return getBookedRides;

        }

        public async Task<BookRide> BookRide(BookRide bookRideRequest)
        {
            var bookRide = new BookRide()
            {
                BookRideId = Guid.NewGuid(),
                UserName = bookRideRequest.UserName,
                OfferRideId = bookRideRequest.OfferRideId,
                UserId = bookRideRequest.UserId,
                StartPoint = bookRideRequest.StartPoint,
                EndPoint = bookRideRequest.EndPoint,
                TimeSlot = bookRideRequest.TimeSlot,
                Date = bookRideRequest.Date,
                Price = bookRideRequest.Price,
                Seats = bookRideRequest.Seats,
            };
            BookRide bookedRide = await this._bookRideRepository.BookRide(bookRide);
            return bookedRide;

        }
    }
}
