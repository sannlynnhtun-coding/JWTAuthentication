namespace JWTAuthentication.Features.Login;

public class LoginResponse : ResponseStatus
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

}