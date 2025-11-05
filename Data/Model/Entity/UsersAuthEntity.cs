using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entity;

public class UsersAuthEntity
{
    public Guid UserId { get; init; } = Guid.NewGuid();
    public UsersDataEntity? Data { get; set; } 
    
    [MaxLength(50)]
    public required string Username { get; init; } 
    public required byte[] PasswordHash { get; init; } 
    public byte[]? RefreshTokenHash { get; init; } 
}