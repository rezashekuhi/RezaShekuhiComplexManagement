using ComplexManagement.Services.ComplexUsageTypes;
using ComplexManagment.Entities;
using ComplexManagment.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.Persistence.Ef.Repositories.ComplexUsageTypes
{
    public class EFComplexUsageTypeRepository : ComplexUsageTypeRepository
    {
        private readonly EFDataContext _context;
        public EFComplexUsageTypeRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(ComplexUsageType complexUsageType)
        {
            _context.Add(complexUsageType);

        }

        public bool IsduplicateId(int complexId, int usageId)
        {
            return _context.ComplexUsageTypes.Any(_ => _.ComplexId == complexId
            && _.UsageTypeId == usageId);
        }
    }
}
