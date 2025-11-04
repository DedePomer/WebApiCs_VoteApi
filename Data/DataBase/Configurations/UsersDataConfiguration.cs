using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class UsersDataConfiguration:IEntityTypeConfiguration<UsersDataEntity>
{
    public void Configure(EntityTypeBuilder<UsersDataEntity> builder)
    {
        builder
            .HasKey(e => e.DataId);

        builder
            .HasOne(e => e.User)
            .WithOne(e=>e.Data)
            .HasForeignKey<UsersDataEntity>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}