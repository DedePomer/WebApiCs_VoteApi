namespace Data.Model.Entity;

public class CandidatesEntity
{
    public required Guid CandidateId { get; init; } 
    public required UsersAuthEntity User { get; init; } 
    
    public string? Programm { get; set; } 
}