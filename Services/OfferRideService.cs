using CarPooling.Models;
using CarPooling.Repositories;
using CarPooling.RequestDTOs;
using CarPooling.ResponseDTOs;
using CarPooling.Interfaces;

namespace CarPooling.Services
{
    public class OfferRideService:IOfferRideService
    {
        private readonly OfferRideRepository _offerRideRepository;
        public OfferRideService(OfferRideRepository offerRideRepository)
        {
            this._offerRideRepository = offerRideRepository;
        }

        public async Task<OfferRide> OfferRide(OfferRideRequest offerRideRequest)
        {
            var offerRide = new OfferRide()
            {
                OfferRideId = Guid.NewGuid(),
                UserId = offerRideRequest.UserId,
                UserName = offerRideRequest.UserName,
                StartPoint = offerRideRequest.StartPoint,
                EndPoint = offerRideRequest.EndPoint,
                TimeSlot = offerRideRequest.TimeSlot,
                Date = offerRideRequest.Date,
                Price = offerRideRequest.Price,
                stops = offerRideRequest.stops,
                Seats = offerRideRequest.Seats,
            };
            OfferRide getOfferRide =await  this._offerRideRepository.OfferRide(offerRide);
            return getOfferRide;
        }

        public async Task<List<OfferRide>> GetAllOfferedRides()
        {
            List<OfferRide> getAllOfferedRides = await this._offerRideRepository.GetAllOfferedRides();
            return getAllOfferedRides;
        }

        public async Task<List<OfferRideResponseDTO>> GetOfferedRides(OfferRideRequestDTO offerRideRequestDTO)
        {
            List<OfferRideResponseDTO> getOfferedRides = await this._offerRideRepository.GetOfferedRides(offerRideRequestDTO);
            return getOfferedRides;
        }
    }
}
