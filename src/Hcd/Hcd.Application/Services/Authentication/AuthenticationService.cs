using Hcd.Common.Exceptions;
using Hcd.Data.Entities.Authentication;
using System.Security.Cryptography;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Requests.Token;
using Hcd.Common;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Hcd.Data.Instances;
using Hcd.Application.Managers.Authentication;


namespace Hcd.Application.Services.Authentication
{
    public class AuthenticationService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private AuthenticationManager AuthenticationManager => GetService<AuthenticationManager>();
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            // check user exist
            var existingUser = await AuthenticationManager.FirstOrDefaultAsync(o => request.Email == o.Email);
            if (existingUser != null)
            {
                throw new DuplicateException("User exits!");
            };
           // Generate a salt using RandomNumberGenerator
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var newUser = request.Adapt<User>();
            newUser.Salt = salt;
            newUser.Password = PasswordHandler.HashPassword(request.Password, salt);

            await AuthenticationManager.AddAsync(newUser);
            await UnitOfWork.SaveChangesAsync();

            var response = Mapper.Map<RegisterResponse>(newUser);
            return response;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            // check user doesn't exist
            var jwtAccessExpiration = EnvGlobal.JwtAccessExpiration;
            var existingUser = await AuthenticationManager.FirstOrDefaultAsync(o => request.Email == o.Email) ?? throw new DuplicateException("User not Found!");
            ;

            // authorize
            var passwordRequest = PasswordHandler.HashPassword(request.Password, existingUser.Salt!);
            if (existingUser.Password != passwordRequest)
            {
                throw new UnauthorizedException("Email or Password Invalid");
            }

            var tokenPayload = new GeneratorTokenPayload
            {
                UserId = existingUser.Id,
                Email = existingUser.Email
            };
            if (request.RememberMe == true)
            {
                jwtAccessExpiration = EnvGlobal.JwtRefreshExpiration;
            }
            var accessToken = JwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtAccessSecret, jwtAccessExpiration);
            var refreshToken = JwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtRefreshSecret, EnvGlobal.JwtRefreshExpiration);

            var response = Mapper.Map<LoginResponse>(existingUser);
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;

            return response;
        }

        public Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var RefreshTokenDecoder = handler.ReadJwtToken(request.RefreshToken);

            var tokenPayload = new GeneratorTokenPayload
            {
                UserId = Guid.Parse(RefreshTokenDecoder.Claims.First(claim => claim.Type == "sub").Value),
                Email = RefreshTokenDecoder.Claims.First(claim => claim.Type == "email").Value,
            };

            var verifyToken = JwtTokenGenerator.VerifyRefreshToken(request.RefreshToken);

            var newAccessToken = JwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtAccessSecret, EnvGlobal.JwtAccessExpiration);

            var accessToken = new { AccessToken = newAccessToken };
            var response = Mapper.Map<RefreshTokenResponse>(accessToken);
            return Task.FromResult(response);
        }
    }
}