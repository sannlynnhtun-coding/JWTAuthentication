namespace JWTAuthentication.Features.GetUserInfoById;

public class GetUserInfoByIdRequest
{
    [Required]
    public Guid Id { get; set; }
}
