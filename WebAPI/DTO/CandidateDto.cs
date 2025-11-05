using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class CandidateDto
{
    [Required]
    public int? Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    [Required]
    public string? Program { get; set; }
}