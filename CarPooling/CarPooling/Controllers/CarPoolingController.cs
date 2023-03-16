using CarPooling.Data;
using CarPooling.Models ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CarPoolingController : Controller
    {
        private readonly CarPoolingDbContext dbContext;
        public CarPoolingController(CarPoolingDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("ride")]
        public async Task<IActionResult> GetRides()
        {
            return Ok(await dbContext.Rides.ToListAsync());
        }
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }
        
        [HttpPost]
        [Route("ride")]
        public async Task<IActionResult> AddRide(AddRideRequest addRideRequest)
        {
            var ride = new Ride()
            {
                id = Guid.NewGuid(),
                name = addRideRequest.name,
                startPoint = addRideRequest.startPoint,
                endPoint = addRideRequest.endPoint,
                date = addRideRequest.date,
                startTime = addRideRequest.startTime,
                price= addRideRequest.price,
                endTime= addRideRequest.endTime,
                seats= addRideRequest.seats,
                rideType=addRideRequest.rideType,   
            };
            await dbContext.Rides.AddAsync(ride);
            await dbContext.SaveChangesAsync();
            return Ok(ride);
        }
        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                id = Guid.NewGuid(),
                fullName= addUserRequest.fullName,  
                email = addUserRequest.email,
                password = addUserRequest.password
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRide([FromRoute] Guid id)
        {
            var ride = await dbContext.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }
            return Ok(ride);
        }
       
    }

}
//hhh
