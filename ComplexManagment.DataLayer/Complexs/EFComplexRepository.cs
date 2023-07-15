using ComplexManagement.Services.Complexes;
using ComplexManagement.Services.Complexes.Dto;
using ComplexManagment.Entities;
using ComplexManagment.Persistence.Ef;

namespace ComplexManagment.Persistence.Ef.Repositories.Complexs;

public class EFComplexRepository : ComplexRepository
{
    private readonly EFDataContext _context;

    public EFComplexRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Complex complex)
    {
        _context.Complexs.Add(complex);

    }

    public List<GetAllComplexByNameDto> GetAll(int id,string? searchName)
    {
        var result = _context.Complexs
            .Select(_ => new GetAllComplexByNameDto
            {
                Id = _.Id,
                Name = _.Name,
                NumberOfRegisteredUnits = _.Blooks.SelectMany(_ => _.Units).Count(),
                NumberOfUnregisteredUnits = _.UnitCount - _.Blooks.SelectMany(_ => _.Units).Count()
            });

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            result = result.Where(_ => _.Name.Contains(searchName));
        }

        if (id>0) 
        {
            result = result.Where(_ => _.Id == id);
        }

        return result.ToList();
    }

    public bool IsExistsById(int id)
    {
        return _context.Complexs.Any(_ => _.Id == id);
    }

    public int GetUnitCountById(int id)
    {
        return _context.Complexs
            .Where(_ => _.Id == id)
            .Select(_ => _.UnitCount)
            .FirstOrDefault();
    }

    public List<GetUsageTypeComplexDto> GetComplexOfUsagetype(int id)
    {
        return (from complexUsageType in _context.ComplexUsageTypes
                join usageType in _context.UsageTypes on complexUsageType.UsageTypeId equals usageType.Id
                where complexUsageType.ComplexId == id
                select new GetUsageTypeComplexDto
                {
                    UsageTypeId = complexUsageType.UsageTypeId,
                    UsageTypeTitle = usageType.Title
                }).ToList();
    }

    public List<Blook> GetUnitCountBlookById(int id)
    {
        return _context.Blooks.Where(_ => _.ComplexId == id).ToList();



    }

    public Complex GetById(int id)
    {
        return _context.Complexs.FirstOrDefault(_ => _.Id == id);

    }

    public void Update(Complex complex)
    {
        _context.Complexs.Update(complex);
    }

    public GetComplexByIdWithBlocksDto GetComplexByIdWithBlocksDto(int id)
    {
        return _context.Complexs.Where(_ => _.Id == id)
            .Select(_ => new GetComplexByIdWithBlocksDto
            {
                Id = _.Id,
                Name=_.Name,
                Blocks=_context.Blooks.Select(_=> new GetBlockDto
                {
                    BlockId=_.Id,
                    BlockName=_.Name,
                    BlockUnitCount=_.UnitCount,
                    UnitRegisteredCount=_.Units.Count()
                }).ToList()
            }).FirstOrDefault();
    }

    public bool CheckToHaveAUnit(int id)
    {
        return _context.Complexs.Where(_ => _.Id == id)
            .Any(_ => _.Blooks.Count() != 0);
    }

    public GetComplexByIdDto GetComplexById(int id)
    {
        return _context.Complexs.Where(_ => _.Id == id)
            .Select(_ => new GetComplexByIdDto
            {
                Id= _.Id,
                Name=_.Name,
                NumberOfRegisteredUnits=_context.Blooks.SelectMany(_=>_.Units).Count(),
                NumberOfUnregisteredUnits=_.UnitCount-_context.Blooks.SelectMany(_=>_.Units).Count(),
                NumberOfRegisteredBlook=_.Blooks.Count()
            }).FirstOrDefault();
    }
}