using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entity;

public class CandidatesEntity
{
    public Guid CandidateId { get; init; } = Guid.NewGuid();
    public required Guid UserId { get; init; } 
    public UsersAuthEntity? User { get; init; } 
    public List<VotesEntity>? Votes { get; init; }
    
    [MaxLength(400)]
    public string? Program { get; init; } 
    
    
}