using CarPooling.Models;
using CarPooling.RequestDTOs;

namespace CarPooling.Interfaces
{
    public interface IBookRideService
    {
        Task<List<BookRide>> GetBookedRides();
        Task<BookRide> BookRide(BookRideRequest bookRideRequest);

    }
}
