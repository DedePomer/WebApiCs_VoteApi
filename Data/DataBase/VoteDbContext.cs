using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.DataBase;

public class VoteDbContext: DbContext
{
    public DbSet<UsersAuthEntity>  UsersAuth { get; set; }
    public DbSet<UsersDataEntity>  UsersData { get; set; }
    public DbSet<CandidatesEntity>  Candidates { get; set; }
}