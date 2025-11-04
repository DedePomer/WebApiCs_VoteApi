using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entity;

public class UsersDataEntity
{
    public Guid DataId { get; init; } = Guid.NewGuid();
    public Guid? UserId { get; set; } 
    public UsersAuthEntity? User { get; set; } 
    
    public required bool IsService { get; init; } 
    [MaxLength(50)]
    public required string FirstName { get; init; } 
    [MaxLength(50)]
    public string? Surname { get; set; } 
    [MaxLength(400)]
    public string? Description { get; set; } 
    public byte[]? Photo { get; set; } 
    public int? Age { get; set; } 
}