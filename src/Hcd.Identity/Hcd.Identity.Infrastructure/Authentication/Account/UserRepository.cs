using Hcd.Identity.Application.Common.Interfaces.Authentication.Account;
using Hcd.Identity.Data.Entities.Authentication;

namespace Hcd.Identity.Infrastructure.Authentication.Account
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }
        // protected async Task<IActionResult> RequestAsGet<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        // {
        //     var response = await Mediator.Send(request, "");
        //     return Ok(response);
        // }

        // protected async Task<IActionResult> RequestAsCreate<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        // {
        //     var response = await Mediator.Send(request);
        //     return Created("", response);
        // }

        // protected async Task<IActionResult> RequestAsUpdate<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        // {
        //     var response = await Mediator.Send(request);
        //     return Ok(response);
        // }

        // protected async Task<IActionResult> RequestAsDelete<TRequest>(TRequest request) where TRequest : IRequest
        // {
        //     await Mediator.Send(request);
        //     return Ok();
        // }

        // protected async Task<IActionResult> RequestAsAction<TRequest>(TRequest request) where TRequest : IRequest
        // {
        //     await Mediator.Send(request);
        //     return Ok();
        // }
    }
}