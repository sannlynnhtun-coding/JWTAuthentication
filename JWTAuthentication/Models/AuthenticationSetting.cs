namespace JWTAuthentication.Models;

public class AuthenticationSetting
{
    [Key]
    public int Id { get; set; }
    public string ModuleName { get; set; }
    public string Action { get; set; }
}