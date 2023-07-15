using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Complexes.Dto
{
    public class GetComplexByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRegisteredUnits { get; set; }
        public int NumberOfUnregisteredUnits { get; set; }
        public int NumberOfRegisteredBlook { get; set; }
    }
}
