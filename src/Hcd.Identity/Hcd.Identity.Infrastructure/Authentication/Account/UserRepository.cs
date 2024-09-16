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
    }
}