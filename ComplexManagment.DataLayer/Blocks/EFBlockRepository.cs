using ComplexManagement.Services.Blooks;
using ComplexManagement.Services.Blooks.Dto;
using ComplexManagment.Entities;

namespace ComplexManagment.Persistence.Ef.Repositories.Blocks;

public class EFBlockRepository : BlockRepository
{
    private readonly EFDataContext _context;

    public EFBlockRepository(EFDataContext context)
    {
        _context = context;
    }

    public bool IsDuplicateNameByComplexId(string name, int complexId)
    {
        return _context.Blooks.Any(_ =>
            _.ComplexId == complexId &&
            _.Name == name);
    }

    public int GetTotalUnitCountByComplexId(int complexId)
    {
        return _context.Blooks
            .Where(_ => _.ComplexId == complexId)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public int GetTotalUnitCountByComplexIdWithOutThisBlockId(
        int id,
        int complexId)
    {
        return _context.Blooks.Where(_ =>
                _.ComplexId == complexId &&
                _.Id != id)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public void Add(Blook blook)
    {
        _context.Blooks.Add(blook);

    }

    public Blook? FindById(int id)
    {
        return _context.Blooks
            .FirstOrDefault(_ => _.Id == id);
    }

    public bool IsDuplicateNameByComplexId(
        int id,
        string name,
        int complexId)
    {
        return _context.Blooks
            .Any(_ => _.Name == name &&
                      _.ComplexId == complexId &&
                      _.Id != id);
    }

    public void Update(Blook blook)
    {
        _context.Blooks.Update(blook);

    }

    public bool CheckBlookId(int id)
    {
        return _context.Blooks.Any(_ => _.Id == id);
    }

    public List<GetAllBlookDto> GetAllBlook()
    {
        return _context.Blooks.Select(_ => new GetAllBlookDto
        {
            Id = _.Id,
            Name = _.Name,
            UnitCount = _.UnitCount,
            Units = _.Units.Select(_ => new GetUnitDto
            {
                UnitId = _.Id,
                Name = _.Name,
                Resident = _.Resident
            }).ToList()

        }).ToList();
    }
    public void updateRange(Blook blook)
    {
        _context.Blooks.UpdateRange(blook);
    }

    public void UpdateRange(List<Blook> blooks)
    {
        _context.UpdateRange(blooks);
    }

    public void AddBlockAndUnitRegistration(Blook blook, HashSet<Unit> unit)
    {
        _context.Add(blook);
        _context.AddRange(unit);
    }
}