using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Blooks.Dto
{
    public class AddBlockAndUnitRegistrationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int UnitCount { get; set; }
        [Required]
        public int ComplexId { get; set; }
        public List<AddUnit> Units { get; set; }

    }
    public class AddUnit { 
        [Required]
        [MaxLength(255)]
        public string UnitName { get; set; }
        [Required]
        public UnitType Resident { get; set; }
    }
}
