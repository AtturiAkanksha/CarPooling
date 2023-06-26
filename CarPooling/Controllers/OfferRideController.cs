using Microsoft.AspNetCore.Mvc;
using CarPooling.API.RequestDTOs;
using Carpooling.DomainModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CarPooling.API.ResponseDTOs;
using CarPooling.Services.Contracts;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace CarPooling.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class OfferRidecontroller : ControllerBase
    {
        private readonly IOfferRideService _offerRideService;
        private readonly IMapper _mapper;
        private ClaimsPrincipal user => HttpContext.User;
        int userId => (int)Convert.ToInt64(user.FindFirst("UserId")?.Value);
        string userEmail => user.FindFirst("UserEmail")?.Value;



        public OfferRidecontroller(IOfferRideService offerRideService, IMapper mapper)
        {
            _offerRideService = offerRideService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("getAllOfferedRides")]
        [ProducesResponseType(typeof(IEnumerable<OfferRide>), StatusCodes.Status200OK)]
        public IEnumerable<OfferRide> GetAllOfferedRides()
        {
            try
            {
                IEnumerable<OfferRide> offeredRides = _offerRideService.GetAllOfferedRides();
                foreach (OfferRide ride in offeredRides)
                {
                    if (userId != ride.UserId)
                    {
                        return offeredRides;
                    }
                }
                throw new Exception("No offered rides yet");
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("getOfferedRides")]
        [ProducesResponseType(typeof(List<OfferRideResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOfferedRides([FromBody] RidesRequest offerRideRequestDTO)
        {
            try
            {
                List<OfferRideResponse> getOfferedRides = _mapper.Map<List<OfferRideResponse>>(await _offerRideService.GetOfferedRides(_mapper.Map<OfferRide>(offerRideRequestDTO)));
                if (getOfferedRides != null)
                {
                    foreach (OfferRideResponse ride in getOfferedRides)
                    {
                        string userName = Regex.Replace(userEmail, @"^(.+)@.*$", "$1");
                        if (userName != ride.UserName)
                        {
                            return Ok(getOfferedRides);
                        }
                    }
                }
                throw new Exception("Sorry! no rides found for booking");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("offerRide")]
        [ProducesResponseType(typeof(BookRide), StatusCodes.Status200OK)]
        public async Task<IActionResult> OfferRide([FromBody] OfferRideRequest offerRideRequest)
        {
            try
            {
                OfferRide _offerRide = _mapper.Map<OfferRide>(offerRideRequest);
                _offerRide.UserId = userId;
                return Ok(await _offerRideService.OfferRide(_offerRide));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
