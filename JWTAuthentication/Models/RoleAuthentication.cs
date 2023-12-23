namespace JWTAuthentication.Models;

public class RoleAuthentication
{
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public int AuthenticationSettingId { get; set; }
    public virtual AuthenticationSetting AuthenticationSetting { get; set; }
}