using CarPooling.Models;
using CarPooling.Services;
using CarPooling.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CarPooling.RequestDTOs;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class OfferRidecontroller : ControllerBase
    {
        private readonly OfferRideService _offerRideService;
        private IConfiguration _config;
        public OfferRidecontroller( IConfiguration configuration, OfferRideService offerRideService)
        {
            _config = configuration;
            _offerRideService = offerRideService;
        }

        [HttpGet]
        [Route("getAllOfferedRides")]
        public async Task<IActionResult> GetAllOfferedRides()
        {
            List<OfferRide> getAllOfferedRides = await this._offerRideService.GetAllOfferedRides();
            return Ok(getAllOfferedRides);
        }

        [HttpPost]
        [Route("offerRide")]
        public async Task<IActionResult> OfferRide([FromBody] OfferRideRequest offerRideRequest)
        { 
          OfferRide getOfferedRide =await _offerRideService.OfferRide(offerRideRequest); 
            return Ok(getOfferedRide);
        }

        [HttpPost]
        [Route("getOfferedRides")]
        public async Task<IActionResult> GetOfferedRides([FromBody] OfferRideRequestDTO offerRideRequestDTO)
        {
            List<OfferRideResponseDTO> getOfferedRides = await _offerRideService.GetOfferedRides(offerRideRequestDTO);
            return Ok(getOfferedRides);
        }
    }
}
