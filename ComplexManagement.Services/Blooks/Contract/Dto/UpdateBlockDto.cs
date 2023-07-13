using System.ComponentModel.DataAnnotations;

namespace ComplexManagement.Services.Blooks.Dto;

public class UpdateBlockDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int UnitCount { get; set; }
}