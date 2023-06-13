using CarPooling.DomainModels;

namespace Carpooling.Data.IRepository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(User userRequest);
    }
}
