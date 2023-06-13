namespace Carpooling.Data.IRepository
{
    public interface IOfferRideRepository
    {
        Task<DomainModels.OfferRide> OfferRide(DomainModels.OfferRide offerRide);
        IEnumerable<DomainModels.OfferRide> GetAllOfferedRides();
        Task<List<DomainModels.OfferRide>> GetOfferedRides(DomainModels.OfferRide offerRide);

    }
}
