using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Users;

namespace Portal.EF.Users.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> _)
    {
        _.HasKey(_=> _.Id);
        _.Property(_ => _.Id).IsRequired();
        _.Property(_ => _.Mobile).IsRequired();
        _.Property(_ => _.Firstname).HasMaxLength(255);
        _.Property(_ => _.Lastname).HasMaxLength(255);
        _.Property(_=>_.Address).HasMaxLength(1000);
        _.Property(_ => _.Email);
        _.Property(_=>_.City).HasMaxLength(255);
        _.Property(_=>_.IsActiveMobile).IsRequired();
        _.Property(_=>_.County).HasMaxLength(255);
        _.Property(_ => _.Mobile).HasMaxLength(20);
        _.Property(_=>_.Company).HasMaxLength(255);
        _.Property(_ => _.Wallet).IsRequired();
        _.Property(_ => _.ActiveCode).HasMaxLength(20);
        _.Property(_ => _.DateOfBirth);
        _.Property(_ => _.Education).HasMaxLength(255);
        _.Property(_ => _.FatherName).HasMaxLength(255);
        _.Property(_ => _.Token);
        _.Property(_=>_.Geneder).IsRequired();
        


    }
}
