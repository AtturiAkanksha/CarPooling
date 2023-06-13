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
            return await this._offerRideRepository.OfferRide(offerRideRequest);
        }

        public IEnumerable<OfferRide> GetAllOfferedRides()
        {
            return (List<OfferRide>)this._offerRideRepository.GetAllOfferedRides();
        }

        public async Task<List<OfferRide>> GetOfferedRides(OfferRide offerRide)
        {
            return await this._offerRideRepository.GetOfferedRides(offerRide);
        }
    }
}

