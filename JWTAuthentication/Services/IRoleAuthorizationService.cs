namespace JWTAuthentication.Interfaces.Services;

public interface IRoleAuthorizationService
{
    Task<bool> IsAuthorized(int roleId, string moduleName, string actionName);
}