namespace JWTAuthentication.Models;

public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdadtedBy { get; set; }
    public bool IsActive { get; set; }
}