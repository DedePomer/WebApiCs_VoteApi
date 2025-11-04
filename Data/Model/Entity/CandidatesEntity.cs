using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entity;

public class CandidatesEntity
{
    public required Guid CandidateId { get; init; } 
    public UsersAuthEntity? User { get; init; } 
    [MaxLength(400)]
    public string? Programm { get; set; } 
}