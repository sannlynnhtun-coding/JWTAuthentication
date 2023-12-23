namespace JWTAuthentication.Context;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions options) : base(options)
    {
    }

    protected AuthContext()
    {
    }

    public virtual DbSet<User> User { get; set; }
    //public virtual DbSet<UserType> UserType { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<AuthenticationSetting> AuthenticationSetting { get; set; }
    public virtual DbSet<RoleAuthentication> RoleAuthentication { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleAuthentication>()
            .HasKey(k => new { k.RoleId, k.AuthenticationSettingId });
    }
}