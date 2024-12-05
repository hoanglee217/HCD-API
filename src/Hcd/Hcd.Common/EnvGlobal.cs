using Hcd.Common.Exceptions;

namespace Hcd.Common
{
    public class EnvGlobal
    {
        public static readonly string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NotFoundException("CONNECTION_STRING is not set in the .env file.");
        public static readonly string DbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new NotFoundException("DB_HOST is not set in the .env file.");
        public static readonly string DbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new NotFoundException("DB_PORT is not set in the .env file.");
        public static readonly string DbName = Environment.GetEnvironmentVariable("DB_NAME") ?? throw new NotFoundException("DB_NAME is not set in the .env file.");
        public static readonly string DbUser = Environment.GetEnvironmentVariable("DB_USER") ?? throw new NotFoundException("DB_USER is not set in the .env file.");
        public static readonly string DbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new NotFoundException("DB_PASSWORD is not set in the .env file.");
        public static readonly string ApiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? throw new NotFoundException("API_BASE_URL is not set in the .env file.");

        public static readonly string JwtAccessSecret = Environment.GetEnvironmentVariable("JWT_ACCESS_SECRET") ?? throw new NotFoundException("JWT_ACCESS_SECRET is not set in the .env file.");
        public static readonly string JwtRefreshSecret = Environment.GetEnvironmentVariable("JWT_REFRESH_SECRET") ?? throw new NotFoundException("JWT_REFRESH_SECRET is not set in the .env file.");
        public static readonly int JwtAccessExpiration = int.Parse(Environment.GetEnvironmentVariable("JWT_ACCESS_EXPIRATION") ?? throw new NotFoundException("JWT_ACCESS_EXPIRATION is not set in the .env file."));
        public static readonly int JwtRefreshExpiration = int.Parse(Environment.GetEnvironmentVariable("JWT_REFRESH_EXPIRATION") ?? throw new NotFoundException("JWT_REFRESH_EXPIRATION is not set in the .env file."));
        public static readonly string JwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new NotFoundException("JWT_AUDIENCE is not set in the .env file.");
        public static readonly string JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new NotFoundException("JWT_ISSUER is not set in the .env file.");
    }
}