using Hcd.Identity.Data.Entities.Authentication;

namespace Hcd.Identity.Application.Common.Interfaces.Authentication.Account
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}