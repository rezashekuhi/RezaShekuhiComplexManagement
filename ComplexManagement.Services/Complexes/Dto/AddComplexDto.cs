using System.ComponentModel.DataAnnotations;

namespace ComplexManagement.Services.Complexes.Dto
{
    public class AddComplexDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(4, 1000)]
        public int UnitCount { get; set; }
    }
}
