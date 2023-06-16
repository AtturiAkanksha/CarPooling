using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarPooling.Services.Contracts;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using CarPooling.DomainModels;
using System.Security.Claims;

namespace CarPooling.Services
{
    public class TokenService : ITokenService
    {
        IConfiguration _config;

        public TokenService(IConfiguration configuration)
        {
            this._config = configuration;
        }

        public string GenerateToken(User user)
        {
            try
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim("Password", user.Password.ToString()),
            };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
