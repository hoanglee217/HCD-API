using System.Net;
using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Authentication.Account;
using Hcd.Identity.Contracts.Requests.Authentication;
using Hcd.Identity.Data.Entities.Authentication;
using Hcd.Shared.Common.Exceptions;

namespace Hcd.Identity.Application.Services.Authentication
{
    public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            // check user exist
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                throw new DuplicateException("User exits!");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            };

            _userRepository.Add(newUser);

            var response = new RegisterResponse(
                newUser
            );

            return Task.FromResult(response);
        }

        public Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            // check user doesn't exist
            var user = _userRepository.GetUserByEmail(request.Email) ?? throw new NotFoundException("User not found");
            // authorize
            if (user.Password != request.Password)
            {
                throw new ArgumentException("Password Invalid");
            }
            
            var token = _jwtTokenGenerator.GeneratorToken(user.Id, request.Email);

            var response = new LoginResponse(user, token);

            return Task.FromResult(response);
        }
    }
}