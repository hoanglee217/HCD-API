using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Hcd.Application.Common.Interfaces.Authentication;
using Hcd.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Hcd.Common;

namespace Hcd.Infrastructure.Authentication
{
    public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IConfiguration configuration) : IJwtTokenGenerator
    {
        public readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        public readonly IConfiguration _configuration = configuration;

        public string GeneratorToken(Guid userId, string email, string? firstName, string? lastName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Env.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.GivenName, lastName ?? ""),
                    new Claim(JwtRegisteredClaimNames.FamilyName, firstName ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = _dateTimeProvider.UtcNow.AddMinutes(Env.JwtExpiration),
                Issuer = Env.JwtIssuer,
                Audience = Env.JwtAudience,
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