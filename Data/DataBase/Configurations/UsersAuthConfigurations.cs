using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class UsersAuthConfigurations:IEntityTypeConfiguration<UsersAuthEntity>
{
    public void Configure(EntityTypeBuilder<UsersAuthEntity> builder)
    {
        builder.HasKey(e => e.UserId);

        builder
            .HasOne(e => e.Data)
            .WithOne(e => e.User);

        builder
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}