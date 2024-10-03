using Hcd.Application.Common.Interfaces.Services;

namespace Hcd.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}