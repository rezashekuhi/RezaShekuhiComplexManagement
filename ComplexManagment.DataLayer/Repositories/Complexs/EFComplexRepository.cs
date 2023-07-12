using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

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

    public List<GetAllComplexByNameDto> GetAll(string? searchName)
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
                where complexUsageType.ComplexId==id 
                select new GetUsageTypeComplexDto{
                 UsageTypeId=complexUsageType.UsageTypeId,
                 UsageTypeTitle=usageType.Title
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
}