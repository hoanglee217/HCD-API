using Hcd.Application.Exceptions;
using Hcd.Application.Manages.Authentication;
using Hcd.Application.Services.Authentication;
using Hcd.Common.Requests.Authentication;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Instances;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Hcd.Application.Tests.Services.Authentication;

public class AuthenticationServiceTests
{
    private readonly Mock<AuthenticationManager> _authenticationManagerMock;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationServiceTests()
    {
        _authenticationManagerMock = new Mock<AuthenticationManager>(null); // Fix: Pass null to the constructor
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(x => x.GetService(typeof(AuthenticationManager))).Returns(_authenticationManagerMock.Object);
        _authenticationService = new AuthenticationService(serviceProviderMock.Object);
    }

    [Fact]
    public async Task Register_ValidRequest_ReturnsRegisterResponse()
    {
        // Arrange
        var registerRequest = new RegisterRequest
        {
            Email = "test@example.com",
            Password = "P@$$wOrd",
            FirstName = "Test",
            LastName = "User"
        };

        _authenticationManagerMock.Setup(x => x.FirstOrDefaultAsync(o => registerRequest.Email == o.Email)).ReturnsAsync((User)null);
        _authenticationManagerMock.Setup(x => x.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

        // Act
        var result = await _authenticationService.Register(registerRequest);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(registerRequest.Email, result.Email);
    }

    [Fact]
    public async Task Register_DuplicateEmail_ThrowsDuplicateException()
    {
        // Arrange
        var registerRequest = new RegisterRequest
        {
            Email = "test@example.com",
            Password = "P@$$wOrd",
            FirstName = "Test",
            LastName = "User"
        };

        _authenticationManagerMock.Setup(x => x.FirstOrDefaultAsync(o => registerRequest.Email == o.Email)).ReturnsAsync(new User { Email = registerRequest.Email });

        // Act & Assert
        await Assert.ThrowsAsync<DuplicateException>(() => _authenticationService.Register(registerRequest));
    }

    // [Fact]
    // public async Task Login_ValidCredentials_ReturnsLoginResponse()
    // {
    //     // Arrange
    //     var loginRequest = new LoginRequest
    //     {
    //         Email = "test@example.com",
    //         Password = "P@$$wOrd",
    //         RememberMe = false
    //     };
    //
    //     var existingUser = new User
    //     {
    //         Id = Guid.NewGuid(),
    //         Email = loginRequest.Email,
    //         Password = PasswordHandler.HashPassword(loginRequest.Password, new byte[16]),
    //         Salt = new byte[16]
    //     };
    //
    //     _authenticationManagerMock.Setup(x => x.FirstOrDefaultAsync(o => loginRequest.Email == o.Email)).ReturnsAsync(existingUser);
    //
    //     // Act
    //     var result = await _authenticationService.Login(loginRequest);
    //
    //     // Assert
    //     Assert.NotNull(result);
    //     Assert.Equal(loginRequest.Email, result.Email);
    //     Assert.NotNull(result.AccessToken);
    //     Assert.NotNull(result.RefreshToken);
    // }

    // [Fact]
    // public async Task Login_InvalidCredentials_ThrowsUnauthorizedException()
    // {
    //     // Arrange
    //     var loginRequest = new LoginRequest
    //     {
    //         Email = "test@example.com",
    //         Password = "wrongPassword",
    //         RememberMe = false
    //     };
    //
    //     var existingUser = new User
    //     {
    //         Id = Guid.NewGuid(),
    //         Email = loginRequest.Email,
    //         Password = PasswordHandler.HashPassword("P@$$wOrd", new byte[16]),
    //         Salt = new byte[16]
    //     };
    //
    //     _authenticationManagerMock.Setup(x => x.FirstOrDefaultAsync(o => loginRequest.Email == o.Email)).ReturnsAsync(existingUser);
    //
    //     // Act & Assert
    //     await Assert.ThrowsAsync<UnauthorizedException>(() => _authenticationService.Login(loginRequest));
    // }

    // [Fact]
    // public async Task Login_UserNotFound_ThrowsDuplicateException()
    // {
    //     // Arrange
    //     var loginRequest = new LoginRequest
    //     {
    //         Email = "test@example.com",
    //         Password = "P@$$wOrd",
    //         RememberMe = false
    //     };
    //
    //     _authenticationManagerMock.Setup(x => x.FirstOrDefaultAsync(o => loginRequest.Email == o.Email)).ReturnsAsync((User)null);
    //
    //     // Act & Assert
    //     await Assert.ThrowsAsync<DuplicateException>(() => _authenticationService.Login(loginRequest));
    // }
}