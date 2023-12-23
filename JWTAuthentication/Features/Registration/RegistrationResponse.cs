namespace JWTAuthentication.Features.Registration;

public class RegistrationResponse : ResponseStatus
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
}