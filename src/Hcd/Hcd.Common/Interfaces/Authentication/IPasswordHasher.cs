namespace Hcd.Application.Common.Interfaces.Authentication
{
    public interface IPasswordHandler
    {
        string HashPassword(string password, byte[] salt);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}