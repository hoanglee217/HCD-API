using Hcd.Common.Exceptions;

namespace Hcd.Common
{
    public class Env
    {
        private static bool _isLoaded = false;

        private static void EnsureEnvLoaded()
        {
            if (!_isLoaded)
            {
                EnvLoader.LoadEnv();
                _isLoaded = true;
            }
        }

        public static readonly string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NotFoundException("CONNECTION_STRING is not set in the .env file.");
        public static readonly string ApiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? throw new NotFoundException("API_BASE_URL is not set in the .env file.");
        public static readonly string JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new NotFoundException("JWT_SECRET is not set in the .env file.");
        public static readonly int JwtExpiration = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRATION_MINUTES") ?? throw new NotFoundException("JWT_EXPIRATION_MINUTES is not set in the .env file."));
        public static readonly string JwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new NotFoundException("JWT_AUDIENCE is not set in the .env file.");
        public static readonly string JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new NotFoundException("JWT_ISSUER is not set in the .env file.");
        private static string GetEnvVariable(string key)
        {
            EnsureEnvLoaded();
            return Environment.GetEnvironmentVariable(key) 
                ?? throw new NotFoundException($"{key} is not set in the .env file.");
        }
    }
}