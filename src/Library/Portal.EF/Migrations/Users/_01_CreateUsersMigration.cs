using FluentMigrator;

namespace Portal.EF.Migrations.Users;

[Migration(01)]
public class _01_CreateUsersMigration : Migration
{

    public override void Up()
    {
        CreateUser();
        CreatePermission();
        CreateRole();
        CreateRolePermission();
        CreateRoleUser();
        CreateUserLoginHistory();
    }
    public override void Down()
    {
        Delete.Table("UserLoginHistories");
        Delete.Table("UserRoles");
        Delete.Table("RolePermissions");
        Delete.Table("Roles");
        Delete.Table("Permissions");
        Delete.Table("Users");
    }
    private void CreateUser()
    {
        Create.Table("Users")
              .WithColumn("Id").AsGuid().Unique().PrimaryKey()
              .WithColumn("Mobile").AsString(255).NotNullable()
              .WithColumn("Email").AsString(550).Nullable()
              .WithColumn("Firstname").AsString(255).Nullable()
              .WithColumn("Lastname").AsString(255).Nullable()
              .WithColumn("Job").AsString(255).Nullable()
              .WithColumn("Education").AsString(255).Nullable()
              .WithColumn("Address").AsString(550).Nullable()
              .WithColumn("Fax").AsString(50).Nullable()
              .WithColumn("Company").AsString(550).Nullable()
              .WithColumn("ZipPostalCode").AsString(50).Nullable()
              .WithColumn("City").AsString().Nullable()
              .WithColumn("County").AsString(250).Nullable()
              .WithColumn("CreatedOnUtc").AsDateTime().Nullable()
              .WithColumn("LastLoginDateUtc").AsDateTime().Nullable()
              .WithColumn("LastActivityDateUtc").AsDateTime().Nullable()
              .WithColumn("DateOfBirth").AsDateTime().Nullable()
              .WithColumn("Geneder").AsByte().Nullable()
              .WithColumn("IsActive").AsBoolean().Nullable()
              .WithColumn("Token").AsString(1000).Nullable()
              .WithColumn("IsActiveEmail").AsBoolean().Nullable()
              .WithColumn("ActiveCode").AsString(20).Nullable()
              .WithColumn("DocumentId").AsGuid().Nullable()
              .WithColumn("Wallet").AsDecimal();

    }
    private void CreatePermission()
    {
        Create.Table("Permissions")
               .WithColumn("Id").AsGuid().Unique().PrimaryKey()
               .WithColumn("Title").AsString(255).NotNullable()
               .WithColumn("Name").AsString(255).NotNullable();
    }

    private void CreateRole()
    {
        Create.Table("Roles")
              .WithColumn("Id").AsGuid().Unique().PrimaryKey()
              .WithColumn("Title").AsString(255).NotNullable();
    }
    private void CreateRolePermission()
    {
        Create.Table("RolePermissions")
              .WithColumn("Id").AsGuid().Unique().PrimaryKey()
              .WithColumn("RoleId").AsGuid().NotNullable()
              .ForeignKey("FK_RolePermissions_Roles", "Roles", "Id")
              .WithColumn("PermissionId").AsGuid().NotNullable()
              .ForeignKey("FK_RolePermissions_Permission", "Permissions", "Id")
              .OnDelete(System.Data.Rule.Cascade);
    }

    private void CreateRoleUser()
    {
        Create.Table("RoleUsers")
              .WithColumn("Id").AsGuid().Unique().PrimaryKey()
              .WithColumn("UserId").AsGuid().NotNullable()
              .ForeignKey("FK_UserRoles_User","Users","Id")
              .WithColumn("RoleId").AsGuid().NotNullable()
              .ForeignKey("FK_UserRoles_Role","Roles","Id");
    }
    private void CreateUserLoginHistory()
    {
        Create.Table("UserLoginHistories")
                 .WithColumn("Id").AsGuid().Unique().PrimaryKey()
                 .WithColumn("IpAddress").AsString(150)
                 .WithColumn("OS").AsString(255).Nullable()
                 .WithColumn("ShortMessage").AsString(255).Nullable()
                 .WithColumn("LoginDate").AsDateTime().WithDefaultValue(DateTime.Now)
                 .WithColumn("IsSuccess").AsBoolean().WithDefaultValue(false)
                 .WithColumn("UserId").AsGuid().Nullable()
                 .ForeignKey("FK_UserLoginHistories_User", "Users", "Id")
                 .OnDelete(System.Data.Rule.Cascade);

    }
}
