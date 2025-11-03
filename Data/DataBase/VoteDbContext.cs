using Data.DataBase.Configurations;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.DataBase;

public class VoteDbContext(DbContextOptions<VoteDbContext> options): DbContext(options)
{
    public DbSet<UsersAuthEntity>  UsersAuth { get; set; }
    public DbSet<UsersDataEntity>  UsersData { get; set; }
    public DbSet<CandidatesEntity>  Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersAuthConfigurations());
        modelBuilder.ApplyConfiguration(new UsersDataConfiguration());
        modelBuilder.ApplyConfiguration(new CandidatesConfigurarion());
        
        base.OnModelCreating(modelBuilder);
    }
}