using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Users;

namespace Portal.EF.Users.Configs;

public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.PermissionId).IsRequired();
        _.Property(_ => _.RoleId).IsRequired();

        _.HasOne(_=>_.Permission)
            .WithMany(_=>_.RolePermissions)
            .HasForeignKey(_=>_.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        _.HasOne(_ => _.Role)
            .WithMany(_ => _.RolePermissions)
            .HasForeignKey(_ => _.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
