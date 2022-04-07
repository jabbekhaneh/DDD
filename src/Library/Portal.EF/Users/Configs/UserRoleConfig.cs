using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Users;

namespace Portal.EF.Users.Configs;

public  class UserRoleConfig : IEntityTypeConfiguration<RoleUser>
{
    public void Configure(EntityTypeBuilder<RoleUser> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.UserId).IsRequired();
        _.Property(_ => _.RoleId).IsRequired();


        _.HasOne(_ => _.Role).WithMany(_ => _.RoleUsers).HasForeignKey(_ => _.RoleId);
        _.HasOne(_=>_.User).WithMany(_ => _.RoleUsers).HasForeignKey(_ => _.UserId);
    }
}
