using Carpooling.DomainModels;

namespace CarPooling.Services.Contracts
{
    public interface IOfferRideService
    {
        Task<OfferRide> OfferRide(OfferRide offerRideRequest);
        IEnumerable<OfferRide> GetAllOfferedRides();
        Task<List<OfferRide>> GetOfferedRides(OfferRide offerRide);
    }
}
