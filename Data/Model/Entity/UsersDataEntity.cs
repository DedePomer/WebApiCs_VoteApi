using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entity;

public class UsersDataEntity
{
    public Guid DataId { get; init; } = Guid.NewGuid();
    public required Guid UserId { get; init; } 
    public UsersAuthEntity? User { get; set; } 
    
    public required bool IsService { get; init; } 
    [MaxLength(50)]
    public required string FirstName { get; init; } 
    [MaxLength(50)]
    public string? Surname { get; init; } 
    [MaxLength(400)]
    public string? Description { get; init; } 
    public byte[]? Photo { get; init; } 
    public int? Age { get; init; } 
}