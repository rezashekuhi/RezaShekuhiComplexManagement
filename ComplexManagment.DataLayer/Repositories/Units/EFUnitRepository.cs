using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public class EFUnitRepository : UnitRepository
{
    private readonly EFDataContext _context;

    public EFUnitRepository(EFDataContext context)
    {
        _context = context;
    }

    public void AddUnit(Unit unit)
    {
        _context.Add(unit);
       
    }

    public bool CheckDuplicateUnitNameAndId(string name, int blookId)
    {
        return _context.Units.Any(
            _ => _.Name == name &&
                 _.BlookId == blookId);
    }

    public int GetBlockUnitCount(int blockId)
    {
        return _context.Blooks
            .Where(_ => _.Id == blockId)
            .Select(_ => _.UnitCount)
            .First();
    }

    public bool IsExistsByBlockId(int blockId)
    {
        return _context.Units.Any(_ => _.BlookId == blockId);
    }

    public int TotalUnitInBlock(int blockId)
    {
        return _context.Units
            .Count(_ => _.BlookId == blockId);
    }
}