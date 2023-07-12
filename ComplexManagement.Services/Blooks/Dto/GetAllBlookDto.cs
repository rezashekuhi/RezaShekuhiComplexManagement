
using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Blooks.Dto
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
        public int UnitId { get; set; }
        public string Name { get; set; }
        public UnitType Resident { get; set; }
    }
}
