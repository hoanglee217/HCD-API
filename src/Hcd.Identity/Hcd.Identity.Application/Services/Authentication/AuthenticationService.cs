using Mapster;
using MapsterMapper;
using Hcd.Shared.Common.Exceptions;
using Hcd.Identity.Data.Entities.Authentication;
using Hcd.Identity.Contracts.Requests.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Authentication.Account;


namespace Hcd.Identity.Application.Services.Authentication
{
    public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper) : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            // check user exist
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                throw new DuplicateException("User exits!");
            }

            var newUser = request.Adapt<User>();

            _userRepository.Add(newUser);

            var response = _mapper.Map<RegisterResponse>(newUser);

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
            
            var token = _jwtTokenGenerator.GeneratorToken(user.Id, user.Email, user.FirstName, user.LastName);

            var response = new LoginResponse(user, token);

            return Task.FromResult(response);
        }
    }
}