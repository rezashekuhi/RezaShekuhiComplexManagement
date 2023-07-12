using ComplexManagement.Services.UsageTypes.Dto;

namespace ComplexManagement.Services.UsageTypes.Contract
{
    public interface UsageTypeService
    {
        void Add(AddUsageTypeDto dto);
        List<GetAllUsageType> GetAll();
    }
}
