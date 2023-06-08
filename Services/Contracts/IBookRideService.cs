using CarPooling.Data.Models;
using CarPooling.RequestDTOs;

namespace CarPooling.Services.Contracts
{
    public interface IBookRideService
    {
        Task<List<BookRide>> GetBookedRides();
        Task<BookRide> BookRide(BookRideRequest bookRideRequest);

    }
}
