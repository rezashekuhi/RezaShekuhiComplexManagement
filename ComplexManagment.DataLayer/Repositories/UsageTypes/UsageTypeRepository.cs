using ComplexManagment.DataLayer.Dto.UsageType;
using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.UsageTypes
{
    public interface UsageTypeRepository
    {
        void Add(UsageType usageType);
        List<GetAllUsageType> getAllUsageTypes();
        bool IsExistById(int id);
        bool IsExistByName(string title);
    }
}
