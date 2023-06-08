using CarPooling.RequestDTOs;
using CarPooling.Repositories;
using CarPooling.Services.Contracts;
using CarPooling.Data.Models;

namespace CarPooling.Services
{
    public class BookRideService:IBookRideService
    {
        private readonly BookRideRepository _bookRideRepository;

        public BookRideService(BookRideRepository bookRideRepository)
        {
            this._bookRideRepository = bookRideRepository;
        }

        public async Task<List<BookRide>> GetBookedRides()
        {
           List<BookRide> getBookedRides = await this._bookRideRepository.GetBookedRides();
            return getBookedRides;

        }

        public async Task<BookRide> BookRide(BookRideRequest bookRideRequest)
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
                BookRide bookedRide =await this._bookRideRepository.BookRide(bookRide);
                return bookedRide;
            
        }
    }
}
