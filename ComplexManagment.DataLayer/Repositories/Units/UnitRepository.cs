using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public interface UnitRepository
{
    bool IsExistsByBlockId(int blockId);
    bool CheckDuplicateUnitNameAndId(string name,int blookId);
    int GetBlockUnitCount(int blockId);
    int TotalUnitInBlock(int blockId);
    void AddUnit(Unit unit);
    
}