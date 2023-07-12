using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.ComplexUsageTypes
{
    public interface ComplexUsageTypeRepository
    {
        void Add(ComplexUsageType complexUsageType);
        bool IsduplicateId(int complexId,int usageId);
    }
}
