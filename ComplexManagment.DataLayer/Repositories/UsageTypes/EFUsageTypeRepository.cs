using ComplexManagment.DataLayer.Dto.UsageType;
using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.UsageTypes
{
   
   
    public class EFUsageTypeRepository : UsageTypeRepository
    {
        
        private readonly EFDataContext _context;

        public EFUsageTypeRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(UsageType usageType)
        {
            _context.UsageTypes.Add(usageType);
            
        }

        public List<GetAllUsageType> getAllUsageTypes()
        {
            return _context.UsageTypes.Select(usageType => new GetAllUsageType
            {
                Id = usageType.Id,
                Title = usageType.Title
            }).ToList();
        }
        public bool IsExistById(int id)
        {
           return _context.UsageTypes.Any(_=>_.Id == id);
        }

        public bool IsExistByName(string title)
        {
            return _context.UsageTypes.Any(_=>_.Title == title);
        }
    }
}
