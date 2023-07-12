using ComplexManagement.Services.UsageTypes.Dto;

using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.UsageTypes
{
    public interface UsageTypeRepository
    {
        void Add(UsageType usageType);
        List<GetAllUsageType> getAllUsageTypes();
        bool IsExistById(int id);
        bool IsExistByName(string title);
    }
}
