using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class UserDto
{
    [Required]
    public string? UserName { get; init; }
    
    [Required]
    public string? Password { get; init; }
}