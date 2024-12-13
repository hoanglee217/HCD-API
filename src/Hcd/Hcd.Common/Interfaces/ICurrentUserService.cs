namespace Hcd.Common.Interfaces
{
    public interface ICurrentUserService
{
    Guid GetCurrentUserId();
    string GetCurrentUserName();
}
}