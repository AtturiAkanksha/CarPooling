using CarPooling.Data.Models;
using CarPooling.RequestDTOs;
using CarPooling.ResponseDTOs;

namespace CarPooling.Services.Contracts
{
    public interface IOfferRideService
    {
         Task<OfferRide> OfferRide(OfferRideRequest offerRideRequest);
        Task<List<OfferRide>> GetAllOfferedRides();
        Task<List<OfferRideResponseDTO>> GetOfferedRides(OfferRideRequestDTO offerRideRequestDTO);
    }
}
