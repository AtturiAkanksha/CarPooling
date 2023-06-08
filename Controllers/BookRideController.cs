using CarPooling.Models;
using CarPooling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CarPooling.RequestDTOs;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BookRideController : Controller
    {
        private IConfiguration _config;
        private readonly BookRideService _bookRideService;
        public BookRideController( IConfiguration configuration, BookRideService bookRideService)
        {
            _config = configuration;
            this._bookRideService = bookRideService;
        }

        [HttpGet]
        [Route("getBookedRides")]
        public async Task<IActionResult> GetBookedRides()
        {
            List<BookRide> getBookedRides =await this._bookRideService.GetBookedRides();
            return Ok(getBookedRides);
        }
       
        [HttpPost]
        [Route("bookRide")]
        public async Task<IActionResult> BookRide(BookRideRequest bookRideRequest)
        {
            BookRide bookedRide =await this._bookRideService.BookRide(bookRideRequest);
                return Ok(bookedRide);
        }
    }
}
