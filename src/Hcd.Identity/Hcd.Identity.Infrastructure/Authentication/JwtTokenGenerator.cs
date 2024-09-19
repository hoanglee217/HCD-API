using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Services;
using Hcd.Shared.Common;
using Hcd.Shared.Common.Constants;
using Microsoft.Extensions.Configuration;

namespace Hcd.Identity.Infrastructure.Authentication
{
    public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IConfiguration configuration) : IJwtTokenGenerator
    {
        public readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        public readonly IConfiguration _configuration = configuration;

        public string GeneratorToken(Guid userId, string email, string firstName, string lastName)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new Exception("Secret key not found.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.GivenName, lastName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, firstName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = _dateTimeProvider.UtcNow.AddDays(1),
                Issuer = "HoangCodeDao",
                Audience = "HoangCodeDao",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token).ToString();
        }
    }
}