using System.ComponentModel.DataAnnotations;

namespace ComplexManagment.DataLayer.Dto.Complexs
{
    public class AddComplexDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(4,1000)]
        public int UnitCount { get; set; }
    }
}
