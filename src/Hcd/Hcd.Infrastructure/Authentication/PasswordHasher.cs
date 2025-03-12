using System.Security.Cryptography;
using Hcd.Application.Common.Interfaces;
using Hcd.Common.Interfaces.Authentication;

namespace Hcd.Infrastructure.Authentication
{
    public class PasswordHandler : IPasswordHandler
    {
        public string HashPassword(string password, byte[] salt)
        {
            // Hash the password with the salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(20); // Length of the hashed password

                // Combine salt and hash for storage
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);  // Salt is the first 16 bytes
                Array.Copy(hash, 0, hashBytes, 16, 20); // Hash is the next 20 bytes

                // Convert the result to a base64 string for storage
                return Convert.ToBase64String(hashBytes);
            }
        }
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Get the bytes from the stored hash
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract the salt (the first 16 bytes)
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Hash the entered password with the same salt, using SHA256 and 10,000 iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits hash

                // Compare the results
                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}


