using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portal.Domain.Users;

namespace Portal.EF;
public class EFdbApplication : DbContext
{
    private readonly string _ConnectionString = String.Empty;
    public EFdbApplication(string connectionString) : this(new DbContextOptionsBuilder<EFdbApplication>().UseSqlite(connectionString).Options)
    {
    }
    private EFdbApplication(DbContextOptions<EFdbApplication> options): this((DbContextOptions)options)
    {
    }

    protected EFdbApplication(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFdbApplication).Assembly);
    }
    //public EFdbApplication() : this("data source =.; initial catalog =_dbPortal; integrated security = True; MultipleActiveResultSets=True")
    //{

    //}

    //public EFdbApplication(string connectionString)
    //{
    //    _ConnectionString = connectionString;
    //}



    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}


    #region Users

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleUser> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserLoginHistory> UserLoginHistories { get; set; }

    #endregion


    public override ChangeTracker ChangeTracker
    {
        get
        {
            var tracker = base.ChangeTracker;
            tracker.LazyLoadingEnabled = false;
            tracker.AutoDetectChangesEnabled = true;
            tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return tracker;
        }
    }





}
