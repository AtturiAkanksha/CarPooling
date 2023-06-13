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
            List<Carpooling.DomainModels.BookRide> _bookedRides = _mapper.Map<List<Carpooling.DomainModels.BookRide>>(bookedRides);
            return _bookedRides;
        }

        public async Task<Carpooling.DomainModels.BookRide> BookRide(Carpooling.DomainModels.BookRide bookRide)
        {
            var offeredRide = dbContext.OfferedRides.FirstOrDefault(x =>
             x.StartPoint == bookRide.StartPoint &&
             x.EndPoint == bookRide.EndPoint &&
             x.TimeSlot == bookRide.TimeSlot &&
             x.Date == bookRide.Date &&
             x.Seats >= bookRide.Seats
           );
            try
            {
                if (offeredRide != null)
                {
                    BookRide _bookRide = _mapper.Map<BookRide>(bookRide);
                    await dbContext.BookedRides.AddAsync(_bookRide);
                    await dbContext.SaveChangesAsync();
                    Carpooling.DomainModels.BookRide bookRideDomain = _mapper.Map<Carpooling.DomainModels.BookRide>(_bookRide);
                    return bookRideDomain;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
