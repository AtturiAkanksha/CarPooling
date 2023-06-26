using AutoMapper;
using Carpooling.Data.IRepository;

namespace CarPooling.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly CarPoolingDbContext dbContext;

        public UserRepository(CarPoolingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DomainModels.User> AddUser(DomainModels.User user)
        {

            var _user = _mapper.Map<DataModels.User>(user);
            var isEmailAlreadyExists = dbContext.Users.Any(x => x.Email == _user.Email);
            try
            {
                if (!isEmailAlreadyExists)
                {
                    await dbContext.Users.AddAsync(_user);
                    await dbContext.SaveChangesAsync();
                    var dbUser = dbContext.Users.FirstOrDefault(x => x.Email == _user.Email);
                    return _mapper.Map<DomainModels.User>(dbUser); 
                }
                throw new Exception("User already exists");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<DomainModels.User> GetUser(DomainModels.User userRequest)
        {
            DataModels.User? _user = _mapper.Map<DataModels.User>(userRequest);
            DataModels.User? existingUser = dbContext.Users.FirstOrDefault(x => x.Email == _user.Email);
            return _mapper.Map<DomainModels.User>(existingUser);
        }
    }
}
