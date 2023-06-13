using CarPooling.DomainModels;
using CarPooling.Services.Contracts;
using Carpooling.Data.IRepository;

namespace CarPooling.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var requestedUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
            };
            User getUser = await _userRepository.AddUser(requestedUser);
            return getUser;
        }

        public async Task<User> GetUser(User UserRequest)
        {
            try
            {
                User existingUser = await _userRepository.GetUser(UserRequest);
                if (existingUser != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(UserRequest.Password, existingUser.Password))
                    {
                        return existingUser;
                    }
                    throw new Exception("password incorrect");
                }
                throw new Exception("User doesn't exists");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
