using CarPooling.Data;
using CarPooling.Models ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class CarPooling : Controller
    {
        private readonly CarPoolingDbContext dbContext;
        private IConfiguration _config;
        public CarPooling(CarPoolingDbContext dbContext, IConfiguration configuration) {
            this.dbContext = dbContext;
            _config = configuration;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                id = Guid.NewGuid(),
                email = addUserRequest.email,
                password = addUserRequest.password
            };
            var isEmailAlreadyExists =  dbContext.Users.Any(x => x.email == user.email);
            if (isEmailAlreadyExists)
            {
                return BadRequest("email already exists");
            }
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
        }
        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }
        
        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> getUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }
        [HttpGet]
        [Route("ride")]
        public async Task<IActionResult> GetRides()
        {
            return Ok(await dbContext.Rides.ToListAsync());
        }

        private string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);   

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt: Andience"],null,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> Login(AddUserRequest addUserRequest)
        {
            IActionResult response = Unauthorized();
            var user = new User()
            {
                email = addUserRequest.email,
                password = addUserRequest.password
            };
            var existingUser = dbContext.Users.FirstOrDefault(x => x.email == user.email);
            if (existingUser != null && existingUser.password == user.password)
            {
                var token = GenerateToken();
               response =   Ok(new{token});
                return response;
            }
            else if (existingUser != null && existingUser.password != user.password)
            {
                return BadRequest("incorrect password");
            }
            return BadRequest("User doesn't exists");
            
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
                price = addRideRequest.price,
                endTime = addRideRequest.endTime,
                seats = addRideRequest.seats,
                rideType = addRideRequest.rideType,
            };
            await dbContext.Rides.AddAsync(ride);
            await dbContext.SaveChangesAsync();
            return Ok(ride);
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
