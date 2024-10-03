namespace Hcd.Application.Common.Interfaces
{
    public interface ICurrentUserService
{
    Guid GetCurrentUserId();
    string GetCurrentUserName();
}
}