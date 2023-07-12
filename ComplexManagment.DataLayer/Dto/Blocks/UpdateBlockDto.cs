using System.ComponentModel.DataAnnotations;

namespace ComplexManagment.DataLayer.Dto.Blocks;

public class UpdateBlockDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int UnitCount { get; set; }
}