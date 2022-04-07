using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Users;

namespace Portal.EF.Users.Configs;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> _)
    {
        _.HasKey(x => x.Id);
        _.Property(_ => _.Id).IsRequired();
        _.Property(_ => _.Title).IsRequired().HasMaxLength(255);

        
    }
}
