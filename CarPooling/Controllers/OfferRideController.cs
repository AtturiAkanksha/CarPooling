using Microsoft.AspNetCore.Mvc;
using CarPooling.API.RequestDTOs;
using Carpooling.DomainModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CarPooling.API.ResponseDTOs;
using CarPooling.Services.Contracts;
using System.Security.Claims;

namespace CarPooling.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class OfferRidecontroller : ControllerBase
    {
        private readonly IOfferRideService _offerRideService;
        private readonly IMapper _mapper;
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
                int userId = (int)Convert.ToInt64(HttpContext.User.FindFirst("UserId")?.Value);
                foreach (OfferRide ride in offeredRides)
                {
                    if (userId != ride.UserId)
                    {
                        return offeredRides;
                    }
                }
                throw new Exception("No offered rides yet");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    return Ok(getOfferedRides);
                }
                else
                {
                    throw new Exception("Sorry! no rides found for booking");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("offerRide")]
        [ProducesResponseType(typeof(BookRide), StatusCodes.Status200OK)]
        public async Task<IActionResult> OfferRide([FromBody] OfferRideRequest offerRideRequest)
        {
            try
            {
                ClaimsPrincipal user = HttpContext.User;
                var userId = HttpContext.User.FindFirst("UserId")?.Value;
                OfferRide _offerRide = _mapper.Map<OfferRide>(offerRideRequest);
                _offerRide.UserId = (int)Convert.ToInt64(userId);
                return Ok(await _offerRideService.OfferRide(_offerRide));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
