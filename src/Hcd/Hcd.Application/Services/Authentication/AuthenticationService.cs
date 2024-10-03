using Mapster;
using MapsterMapper;
using Hcd.Common.Exceptions;
using Hcd.Data.Entities.Authentication;
using Hcd.Application.Common.Interfaces.Authentication;
using System.Security.Cryptography;
using Hcd.Application.Common.Interfaces;
using Hcd.Common.Interface.Authentication;
using Hcd.Common.Contracts.Requests.Authentication;


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

        public Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            // check user exist
            if (_userRepository.GetAll().FirstOrDefault(o => o.Email == request.Email) != null)
            {
                throw new DuplicateException("User exits!");
            }
            // Generate a salt using RandomNumberGenerator
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var newUser = request.Adapt<User>();
            newUser.Salt = salt;
            newUser.Password = _passwordHandler.HashPassword(request.Password, salt);
            _userRepository.Add(newUser);

            var response = _mapper.Map<RegisterResponse>(newUser);
            return Task.FromResult(response);
        }

        public Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            // check user doesn't exist
            var user = _userRepository.GetAll().FirstOrDefault(o => o.Email == request.Email) ?? throw new NotFoundException("User not found");
            // authorize
            var passwordRequest = _passwordHandler.HashPassword(request.Password, user.Salt!);
            if (user.Password != passwordRequest)
            {
                throw new ArgumentException("Password Invalid");
            }
            
            var token = _jwtTokenGenerator.GeneratorToken(user.Id, user.Email, user.FirstName, user.LastName);

            var response = new LoginResponse(user.Id, user.FirstName, user.LastName, user.Email, token);

            return Task.FromResult(response);
        }
    }
}