using Carpooling.Data.IRepository;
using Carpooling.DomainModels;
using CarPooling.Services.Contracts;

namespace CarPooling.Services
{
    public class OfferRideService : IOfferRideService
    {
        private readonly IOfferRideRepository _offerRideRepository;

        public OfferRideService(IOfferRideRepository offerRideRepository)
        {
            this._offerRideRepository = offerRideRepository;
        }

        public async Task<OfferRide> OfferRide(OfferRide offerRideRequest)
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
                Stops = offerRideRequest.Stops,
                Seats = offerRideRequest.Seats,
            };
            OfferRide getOfferRide = await this._offerRideRepository.OfferRide(offerRide);
            return getOfferRide;
        }

        public IEnumerable<OfferRide> GetAllOfferedRides()
        {
            List<OfferRide> getAllOfferedRides = (List<OfferRide>)this._offerRideRepository.GetAllOfferedRides();
            return getAllOfferedRides;
        }

        public async Task<List<OfferRide>> GetOfferedRides(OfferRide offerRide)
        {
            List<OfferRide> _offerRides = await this._offerRideRepository.GetOfferedRides(offerRide);
            return _offerRides;
        }
    }
}

