using CarPooling.Models;
using CarPooling.ResponseDTOs;
using CarPooling.RequestDTOs;

namespace CarPooling.Interfaces
{
    public interface IUserService
    {
         Task<User> CreateUser(UserRequest addUserRequest);
         Task<List<User>>  GetUsers();
         Task<LoginObject> Login(UserRequest addUserRequest);
    }
}
