using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class UserRefreshTokenDto
{
    [Required]
    public string? Username { get; init; }
    
    [Required]
    public byte[]? RefreshTokenHash { get; init; }
}