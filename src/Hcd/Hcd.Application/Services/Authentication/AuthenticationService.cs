using Mapster;
using MapsterMapper;
using Hcd.Common.Exceptions;
using Hcd.Data.Entities.Authentication;
using Hcd.Application.Common.Interfaces.Authentication;
using System.Security.Cryptography;
using Hcd.Common.Interface.Authentication;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Interfaces;
using Hcd.Common.Requests.Token;
using Hcd.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IdentityModel.Tokens.Jwt;


namespace Hcd.Application.Services.Authentication
{
    public class AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHandler passwordHandler,
        IRepository<User> userRepository,
        IMapper mapper
    ) : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IPasswordHandler _passwordHandler = passwordHandler;
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            // check user exist
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(o => o.Email == request.Email);
            if (user != null)
            {
                throw new DuplicateException("User exits!");
            };
            // Generate a salt using RandomNumberGenerator
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var newUser = request.Adapt<User>();
            newUser.Salt = salt;
            newUser.Password = _passwordHandler.HashPassword(request.Password, salt);
            await _userRepository.AddAsync(newUser);

            var response = _mapper.Map<RegisterResponse>(newUser);
            return response;
        }

        public async Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            // check user doesn't exist
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(o => o.Email == request.Email) ?? throw new UnauthorizedException("Email or Password Invalid");
            // authorize
            var passwordRequest = _passwordHandler.HashPassword(request.Password, user.Salt!);
            if (user.Password != passwordRequest)
            {
                throw new UnauthorizedException("Email or Password Invalid");
            }

            var tokenPayload = new GeneratorTokenPayload
            {
                UserId = user.Id,
                Email = user.Email
            };
            var accessToken = _jwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtAccessSecret, EnvGlobal.JwtAccessExpiration);
            var refreshToken = _jwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtRefreshSecret, EnvGlobal.JwtRefreshExpiration);

            // var response = new LoginResponse(user.Id, user.FirstName, user.LastName, user.Email, token);
            var response = _mapper.Map<LoginResponse>(user);
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;

            return response;
        }

        public Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var RefreshTokenDecoder = handler.ReadJwtToken(request.RefreshToken);

            var tokenPayload = new GeneratorTokenPayload
            {
                UserId = Guid.Parse(RefreshTokenDecoder.Claims.First(claim => claim.Type == "sub").Value),
                Email = RefreshTokenDecoder.Claims.First(claim => claim.Type == "email").Value,
            };

            var verifyToken = _jwtTokenGenerator.VerifyRefreshToken(request.RefreshToken);

            var newAccessToken = _jwtTokenGenerator.GeneratorToken(tokenPayload, EnvGlobal.JwtAccessSecret, EnvGlobal.JwtAccessExpiration);

            var accessToken = new {AccessToken = newAccessToken};
            var response = _mapper.Map<RefreshTokenResponse>(accessToken);
            return Task.FromResult(response);
        }
    }
}