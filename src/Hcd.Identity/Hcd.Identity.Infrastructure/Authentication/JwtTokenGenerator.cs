using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Services;
using Hcd.Shared.Common;
using Hcd.Shared.Common.Constants;

namespace Hcd.Identity.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public readonly IDateTimeProvider _dateTimeProvider;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public string GeneratorToken(Guid userId, string email)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                        new Claim("id", userId.ToString()),
                        new Claim("email", email),
                    }),
                Expires = _dateTimeProvider.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("846B62D0-DEF9-4215-A99D-86E6B8DAB342")),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token).ToString();
        }
    }
}