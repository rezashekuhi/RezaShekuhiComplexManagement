using ComplexManagement.Services.Complexes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Complexes.Contracts
{
    public interface ComplexService
    {
        void Add(AddComplexDto dto);
        List<GetAllComplexByNameDto> GetAllSearchByName(int id,string? name);
        List<GetUsageTypeComplexDto> GetUsagetype(int id);
        void EditeUnitcount(int id, int unitCount);
        GetComplexByIdWithBlocksDto GetComplexByIdWithBlocksDto(int id);
        GetComplexByIdDto GetById(int id);
        void Delete(int id);
    }
}
