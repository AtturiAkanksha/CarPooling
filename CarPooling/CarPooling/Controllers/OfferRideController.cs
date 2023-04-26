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
    public class OfferRidecontroller : Controller
    {
        private readonly CarPoolingDbContext dbContext;
        private IConfiguration _config;
        public OfferRidecontroller(CarPoolingDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _config = configuration;
        }

        [HttpGet]
        [Route("getOfferedRides")]
        public async Task<IActionResult> GetOfferedRides()
        {
            return Ok(await dbContext.OfferedRides.ToListAsync());
        }

        [HttpPost]
        [Route("offerRide")]
        public async Task<IActionResult> offerRide(OfferRideRequest offerRideRequest)
        {
            var offerRide = new OfferRide()
            {
                OfferRideId = Guid.NewGuid(),
                UserId = offerRideRequest.UserId,
                UserName= offerRideRequest.UserName,
                StartPoint = offerRideRequest.StartPoint,
                EndPoint = offerRideRequest.EndPoint,
                TimeSlot = offerRideRequest.TimeSlot,
                Date = offerRideRequest.Date,
                Price = offerRideRequest.Price,
                Seats = offerRideRequest.Seats,
                IsActive= offerRideRequest.IsActive,
            };
            await dbContext.OfferedRides.AddAsync(offerRide);
            await dbContext.SaveChangesAsync();
            return Ok(offerRide);
        }

    }
}
