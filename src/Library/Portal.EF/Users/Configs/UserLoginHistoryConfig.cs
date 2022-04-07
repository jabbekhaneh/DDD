using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Users;

namespace Portal.EF.Users.Configs;

public class UserLoginHistoryConfig : IEntityTypeConfiguration<UserLoginHistory>
{
    public void Configure(EntityTypeBuilder<UserLoginHistory> _)
    {

        _.HasKey(_ => _.Id);
        _.Property(_ => _.IpAddress).HasMaxLength(255);
        _.Property(_=>_.ShortMessage).HasMaxLength(550);
        _.Property(_ => _.LoginDate);
        _.Property(_ => _.IsSuccess).IsRequired();
        _.Property(_=>_.OS).IsRequired();
        _.Property(_ => _.UserId).IsRequired();

        _.HasOne(_ => _.User)
            .WithMany(_ => _.UserLoginHistories)
            .HasForeignKey(_=>_.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
