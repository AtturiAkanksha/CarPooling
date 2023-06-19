using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Carpooling.Data.IRepository;
using CarPooling.Data.DataModels;

namespace CarPooling.Data.Repositories
{
    public class OfferRideRepository : IOfferRideRepository
    {
        private readonly CarPoolingDbContext dbContext;
        private readonly IMapper _mapper;

        public OfferRideRepository(CarPoolingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<Carpooling.DomainModels.OfferRide> OfferRide(Carpooling.DomainModels.OfferRide offerRide)
        {
            OfferRide _offerRide = _mapper.Map<OfferRide>(offerRide);
            await dbContext.OfferedRides.AddAsync(_offerRide);
            await dbContext.SaveChangesAsync();
            return _mapper.Map<Carpooling.DomainModels.OfferRide>(_offerRide);
        }

        public IEnumerable<Carpooling.DomainModels.OfferRide> GetAllOfferedRides()
        {
            List<OfferRide> getRides = dbContext.OfferedRides.ToList();
            foreach (OfferRide ride in getRides)
            {
                BookRide? bookedRide = dbContext.BookedRides.FirstOrDefault(x =>
                x.OfferRideId == ride.OfferRideId);
                ride.UserName = bookedRide.UserName;
                ride.UserId = bookedRide.UserId;
            }
            return _mapper.Map<List<Carpooling.DomainModels.OfferRide>>(getRides);
        }

        public async Task<List<Carpooling.DomainModels.OfferRide>> GetOfferedRides(Carpooling.DomainModels.OfferRide _offerRide)
        {
            List<OfferRide> getOfferedRides = await dbContext.OfferedRides.Where(
                offerRide => offerRide.StartPoint == _offerRide.StartPoint &&
                offerRide.EndPoint == _offerRide.EndPoint &&
                offerRide.Date == _offerRide.Date &&
                offerRide.TimeSlot == _offerRide.TimeSlot
                ).ToListAsync();
            return _mapper.Map<List<Carpooling.DomainModels.OfferRide>>(getOfferedRides);
        }
    }
}
