namespace Hcd.Application.Common.Interfaces.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        DateTime VietnamNow { get; }
    }
}