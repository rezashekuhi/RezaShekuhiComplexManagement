using System.ComponentModel.DataAnnotations;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Dto.Units;

public class AddUnitDto
{
    [Required]
    [MaxLength(255)]
    public string Name{ get; set; }
    [Required]
    public int BlookId { get; set; }
    [Required]
    public UnitType Resident { get; set; }
}