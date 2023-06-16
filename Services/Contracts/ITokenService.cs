using CarPooling.DomainModels;

namespace CarPooling.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(User user, int userId);
    }
}
