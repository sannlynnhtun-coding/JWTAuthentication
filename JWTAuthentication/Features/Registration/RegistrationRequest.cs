namespace JWTAuthentication.Features.Registration;

public class RegistrationRequest
{
    public string Email { get; set; }

    public string Password { get; set; }
    public string Name { get; set; }
}