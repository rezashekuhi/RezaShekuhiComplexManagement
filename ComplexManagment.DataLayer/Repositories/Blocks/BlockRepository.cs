using ComplexManagment.DataLayer.Dto.Blocks;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public interface BlockRepository
{
    bool IsDuplicateNameByComplexId(string name,int complexId);
    int GetTotalUnitCountByComplexId(int complexId);
    int GetTotalUnitCountByComplexIdWithOutThisBlockId(int id,int complexId);
    void Add(Blook blook);
    Blook? FindById(int id);
    bool IsDuplicateNameByComplexId(int id, string name, int complexId);
    void Update(Blook blook);
    bool CheckBlookId(int id);
    List<GetAllBlookDto> GetAllBlook();
    void UpdateRange(List<Blook> blooks);
}