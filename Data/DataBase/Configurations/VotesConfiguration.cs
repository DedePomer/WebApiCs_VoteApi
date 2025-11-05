using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataBase.Configurations;

public class VotesConfiguration:IEntityTypeConfiguration<VotesEntity>
{
    public void Configure(EntityTypeBuilder<VotesEntity> builder)
    {
        builder
            .HasKey(v => v.VoteId);
        
        builder
            .HasOne(v=>v.Candidate)
            .WithMany(c=>c.Votes)
            .HasForeignKey(v=>v.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}