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
            try
            {
                List<OfferRide> getAllOfferedRides = (List<OfferRide>)_offerRideService.GetAllOfferedRides();
                return getAllOfferedRides;
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
                List<OfferRide> getOfferedRides = await _offerRideService.GetOfferedRides(_mapper.Map<OfferRide>(offerRideRequestDTO));
                List<OfferRide> getrides = (List<OfferRide>)getOfferedRides.Select(offerRide => new OfferRide
                {
                    UserName = offerRide.UserName,
                    OfferRideId = offerRide.OfferRideId,
                    StartPoint = offerRide.StartPoint,
                    EndPoint = offerRide.EndPoint,
                    Date = offerRide.Date,
                    TimeSlot = offerRide.TimeSlot,
                    Price = offerRide.Price,
                    Seats = offerRide.Seats
                });
                List<OfferRideResponse> _getRides = _mapper.Map<List<OfferRideResponse>>(getrides);
                if (_getRides != null)
                {
                    return Ok(_getRides);
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
            OfferRide getOfferedRide = await _offerRideService.OfferRide(_mapper.Map<OfferRide>(offerRideRequest));
            return Ok(getOfferedRide);
        }


    }
}
