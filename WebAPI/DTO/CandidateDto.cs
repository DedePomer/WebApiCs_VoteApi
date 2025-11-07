using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class CandidateDto
{
    [Required]
    public Guid? CandidateId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    [Required]
    public string? Program { get; set; }
}