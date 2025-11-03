using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class UserDataConfiguration:IEntityTypeConfiguration<UsersDataEntity>
{
    public void Configure(EntityTypeBuilder<UsersDataEntity> builder)
    {
        builder
            .HasKey(e => e.DataId);

        builder
            .HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<UsersDataEntity>(e => e.UserId);
    }
}