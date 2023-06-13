using CarPooling.DomainModels;

namespace CarPooling.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(User UserRequest);
    }
}
