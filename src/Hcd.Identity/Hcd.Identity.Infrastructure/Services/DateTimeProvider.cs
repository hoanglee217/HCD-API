using Hcd.Identity.Application.Common.Interfaces.Services;

namespace Hcd.Identity.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}