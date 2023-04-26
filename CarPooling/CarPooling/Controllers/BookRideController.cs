using CarPooling.Data;
using CarPooling.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class BookRideController : Controller
    {
        private readonly CarPoolingDbContext dbContext;
        private IConfiguration _config;
        public BookRideController(CarPoolingDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _config = configuration;
        }

        [HttpGet]
        [Route("getBookedRides")]
        public async Task<IActionResult> GetBookedRides()
        {
            return Ok(await dbContext.BookedRides.ToListAsync());
        }
       
        [HttpPost]
        [Route("bookRide")]
        public async Task<IActionResult> bookRide(BookRideRequest bookRideRequest)
        {
            var bookRide = new BookRide()
            {
                Id = Guid.NewGuid(),
                Name = bookRideRequest.Name,
                StartPoint = bookRideRequest.StartPoint,
                EndPoint = bookRideRequest.EndPoint,
                StartTime = bookRideRequest.StartTime,
                EndTime = bookRideRequest.EndTime,
                Date = bookRideRequest.Date,
                Seats = bookRideRequest.Seats,
            };
                var offeredRide = dbContext.OfferedRides.FirstOrDefault(x =>
                x.Name != bookRideRequest.Name && 
                x.StartPoint == bookRide.StartPoint &&
                x.EndPoint == bookRide.EndPoint &&
                x.StartTime == bookRide.StartTime &&
                x.EndTime == bookRide.EndTime &&
                x.Date == bookRide.Date &&
                x.Seats >= bookRide.Seats
            );
            if(offeredRide != null)
            {
                await dbContext.BookedRides.AddAsync(bookRide);
                await dbContext.SaveChangesAsync();
                return Ok(bookRide);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBookedRide([FromRoute] Guid id)
        {
            var ride = await dbContext.BookedRides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }
            return Ok(ride);
        }

    }
}
