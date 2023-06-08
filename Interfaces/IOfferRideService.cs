using CarPooling.Models;
using CarPooling.RequestDTOs;
using CarPooling.ResponseDTOs;

namespace CarPooling.Interfaces
{
    public interface IOfferRideService
    {
         Task<OfferRide> OfferRide(OfferRideRequest offerRideRequest);
        Task<List<OfferRide>> GetAllOfferedRides();
        Task<List<OfferRideResponseDTO>> GetOfferedRides(OfferRideRequestDTO offerRideRequestDTO);
    }
}
