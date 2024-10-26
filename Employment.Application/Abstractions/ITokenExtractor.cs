
namespace Employment.Application.Authentication
{
    public interface ITokenExtractor
    {
        string GetEmail();
        Guid GetOtherId();
        string GetRole();
        Guid GetUserId();
        string GetUsername();
        string GetUserRole();
        bool IsUserAuthenticated();
    }
}