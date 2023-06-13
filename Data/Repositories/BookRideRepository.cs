using Carpooling.Data.IRepository;
using CarPooling.Data.DataModels;
using AutoMapper;

namespace CarPooling.Data.Repositories
{
    public class BookRideRepository : IBookRideRepository
    {
        private readonly CarPoolingDbContext dbContext;
        private readonly IMapper _mapper;

        public BookRideRepository(CarPoolingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this._mapper = mapper;
        }

        public IEnumerable<Carpooling.DomainModels.BookRide> GetBookedRides()
        {
            List<BookRide> bookedRides = dbContext.BookedRides.ToList();
            return _mapper.Map<List<Carpooling.DomainModels.BookRide>>(bookedRides);
        }

        public async Task<Carpooling.DomainModels.BookRide> BookRide(Carpooling.DomainModels.BookRide bookRideRequest)
        {
            OfferRide? offeredRide = dbContext.OfferedRides.FirstOrDefault(x =>
             x.StartPoint == bookRideRequest.StartPoint &&
             x.EndPoint == bookRideRequest.EndPoint &&
             x.TimeSlot == bookRideRequest.TimeSlot &&
             x.Date == bookRideRequest.Date &&
             x.Seats >= bookRideRequest.Seats
           );
            try
            {
                if (offeredRide != null)
                {
                    await dbContext.BookedRides.AddAsync(_mapper.Map<BookRide>(bookRideRequest));
                    await dbContext.SaveChangesAsync();
                    return _mapper.Map<Carpooling.DomainModels.BookRide>(bookRideRequest);
                }
                throw new Exception("No rides exists");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
