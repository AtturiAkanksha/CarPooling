using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Carpooling.DomainModels;
using CarPooling.API.RequestDTOs;
using AutoMapper;
using CarPooling.Services.Contracts;

namespace CarPooling.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class BookRideController : ControllerBase
    {
        private readonly IBookRideService _bookRideService;
        private readonly IMapper _mapper;

        public BookRideController(IBookRideService bookRideService, IMapper mapper)
        {
            this._bookRideService = bookRideService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getBookedRides")]
        [ProducesResponseType(typeof(IEnumerable<BookRide>), StatusCodes.Status200OK)]
        public IEnumerable<BookRide> GetBookedRides()
        {
            return this._bookRideService.GetBookedRides();
        }

        [HttpPost]
        [Route("bookRide")]
        [ProducesResponseType(typeof(BookRide), StatusCodes.Status200OK)]
        public async Task<IActionResult> BookRide(BookRideRequest bookRideRequest)
        {
            try
            {
                return Ok(await this._bookRideService.BookRide(_mapper.Map<BookRide>(bookRideRequest)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
