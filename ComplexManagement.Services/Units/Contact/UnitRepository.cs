
using ComplexManagment.Entities;

namespace ComplexManagement.Services.units;

public interface UnitRepository
{
    bool IsExistsByBlockId(int blockId);
    bool CheckDuplicateUnitNameAndId(string name, int blookId);
    int GetBlockUnitCount(int blockId);
    int TotalUnitInBlock(int blockId);
    void AddUnit(Unit unit);

}