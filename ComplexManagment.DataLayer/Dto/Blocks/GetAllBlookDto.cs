using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Blocks
{
    public class GetAllBlookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public List<GetUnitDto> Units { get; set; }
    }
    public class GetUnitDto
    {
        public string Name { get; set; }
        public UnitType Resident { get; set; }
    }
}
