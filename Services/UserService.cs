using CarPooling.Data.Models;
using CarPooling.Repositories;
using Microsoft.Extensions.Configuration;
using CarPooling.RequestDTOs;
using CarPooling.Services.Contracts;
using CarPooling.ResponseDTOs;

namespace CarPooling.Services 
{
    public class UserService:IUserService
    { 
        private IConfiguration _config;
        private readonly TokenService _tokenService;
        private readonly UserRepository _userRepository;

        public UserService( IConfiguration configuration,TokenService tokenService,UserRepository userRepository )
        {
            this._config = configuration;
            this._tokenService = tokenService;
            this._userRepository = userRepository;
        }

        public async Task<User>  CreateUser(UserRequest Request)
        {
            var requestedUser = new User()
            {
                email = Request.email,
                password = Request.password,
            };
            User getUser =await _userRepository.AddUser(requestedUser);
             return getUser;
        }

        public async Task<List<User>> GetUsers()
        {
             List<User> users =  await _userRepository.GetUsers();
            return users;
        }

        public  async Task<LoginObject> Login(UserRequest addUserRequest)
        {
            try
            {
                var existingUser = await _userRepository.Login(addUserRequest);
                if (existingUser != null && existingUser.password == addUserRequest.password)
                {
                    var token = _tokenService.GenerateToken();
                    var loginObject = new LoginObject
                    {
                        NewToken = Convert.ToString(new { token }),
                        UserId = existingUser.id
                    };
                    var response = loginObject;
                    return response;
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
