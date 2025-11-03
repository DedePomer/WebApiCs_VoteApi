using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class CandidateConfigurarion:IEntityTypeConfiguration<CandidatesEntity>
{
    public void Configure(EntityTypeBuilder<CandidatesEntity> builder)
    {
        builder
            .HasKey(e => e.CandidateId);
        
        builder
            .HasOne(e=>e.User)
            .WithOne()
            .HasForeignKey<UsersAuthEntity>(e=>e.UserId);
    }
}