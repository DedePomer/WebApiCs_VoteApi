using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class CandidatesConfigurarion:IEntityTypeConfiguration<CandidatesEntity>
{
    public void Configure(EntityTypeBuilder<CandidatesEntity> builder)
    {
        builder
            .HasKey(e => e.CandidateId);
        
        builder
            .HasOne(e=>e.User)
            .WithOne()
            .HasForeignKey<CandidatesEntity>(e=>e.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);;
    }
}