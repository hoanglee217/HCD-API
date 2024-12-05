using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Hcd.Application.Common.Interfaces.Authentication;
using Hcd.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Hcd.Common;
using Hcd.Common.Requests.Token;
using MapsterMapper;
using Hcd.Common.Exceptions;

namespace Hcd.Infrastructure.Authentication
{
    public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IConfiguration configuration, IMapper mapper) : IJwtTokenGenerator
    {
        public readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        public readonly IConfiguration _configuration = configuration;
        public readonly IMapper _mapper = mapper;

        public string GeneratorToken(GeneratorTokenPayload payload, string signingCredentials, int expiration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingCredentials));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, payload.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, payload.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var tokenDescription = new JwtSecurityToken(
                issuer: EnvGlobal.JwtIssuer,
                audience: EnvGlobal.JwtAudience,
                claims: claims,
                expires: _dateTimeProvider.UtcNow.AddSeconds(expiration),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        }

        public ClaimsPrincipal VerifyRefreshToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(EnvGlobal.JwtRefreshSecret);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = EnvGlobal.JwtIssuer,
                ValidAudience = EnvGlobal.JwtAudience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var response = tokenHandler.ValidateToken(token, validationParameters, out _);
                return response;
            }
            catch (Exception)
            {
                throw new UnauthorizedException($"Refresh token invalid");
            }
        }
    }
}