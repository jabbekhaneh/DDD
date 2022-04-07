using Microsoft.EntityFrameworkCore;
using Portal.Domain.Users;

namespace Portal.EF;
public class EFdbApplication : DbContext
{
    private readonly string _ConnectionString;
    public EFdbApplication() : this("data source =.; initial catalog =_dbPortal; integrated security = True; MultipleActiveResultSets=True")
    {

    }

    public EFdbApplication(string connectionString)
    {
        _ConnectionString = connectionString;
    }

    #region Users

    public  DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<RoleUser>? UserRoles { get; set; }
    public DbSet<Permission>? Permissions { get; set; }
    public DbSet<RolePermission>? RolePermissions { get; set; }
    public DbSet<UserLoginHistory>? UserLoginHistories { get; set; }

    #endregion


}
