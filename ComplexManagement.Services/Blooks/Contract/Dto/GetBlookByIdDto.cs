using ComplexManagement.Services.Blooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Blooks.Contract.Dto
{
    public class GetBlookByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetUnitDto> Units { get; set; }
    }
}
