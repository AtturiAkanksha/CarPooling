using Microsoft.AspNetCore.Mvc;
using CarPooling.API.RequestDTOs;
using Carpooling.DomainModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CarPooling.API.ResponseDTOs;
using CarPooling.Services.Contracts;

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
            return _offerRideService.GetAllOfferedRides();
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
                return Ok(await _offerRideService.OfferRide(_mapper.Map<OfferRide>(offerRideRequest)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
