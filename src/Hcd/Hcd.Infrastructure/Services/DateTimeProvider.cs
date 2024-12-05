using Hcd.Application.Common.Interfaces.Services;

namespace Hcd.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime VietnamNow => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, VietnamTimeZone);
    }
}