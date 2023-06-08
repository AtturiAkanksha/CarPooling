using CarPooling.Data;
using CarPooling.ResponseDTOs;
using CarPooling.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarPooling.RequestDTOs;

namespace CarPooling.Repositories
{

    public class OfferRideRepository
    {
        private readonly CarPoolingDbContext dbContext;
        public OfferRideRepository(CarPoolingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<OfferRide> OfferRide(OfferRide offerRide)
        {
            await dbContext.OfferedRides.AddAsync(offerRide);
            await dbContext.SaveChangesAsync();
            return offerRide;
        }
        public async Task<List<OfferRide>> GetAllOfferedRides()
        {
            List<OfferRide> getAllOfferedRides = await dbContext.OfferedRides.ToListAsync();
            return getAllOfferedRides;
        }

        public async Task<List<OfferRideResponseDTO>> GetOfferedRides(OfferRideRequestDTO offerRideRequestDTO)
        {
            List<OfferRideResponseDTO> getOfferedRides = await dbContext.OfferedRides.Where(
                offerRide => offerRide.StartPoint == offerRideRequestDTO.StartPoint &&
                offerRide.EndPoint == offerRideRequestDTO.EndPoint &&
                offerRide.Date == offerRideRequestDTO.Date &&
                offerRide.TimeSlot == offerRideRequestDTO.TimeSlot 
                ).Select(offerRide=>new OfferRideResponseDTO
                {
                    UserName = offerRide.UserName,
                    OfferRideId = offerRide.OfferRideId,
                    StartPoint=offerRide.StartPoint,
                    EndPoint=offerRide.EndPoint,
                    Date=offerRide.Date,
                    TimeSlot=offerRide.TimeSlot,
                    Price=offerRide.Price,
                    Seats=offerRide.Seats
                }).ToListAsync();
            return getOfferedRides;
        }
    }
}
