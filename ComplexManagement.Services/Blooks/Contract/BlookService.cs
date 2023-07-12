using ComplexManagement.Services.Blooks.Dto;

namespace ComplexManagement.Services.Blooks.Contract
{
    public interface BlookService
    {
        void Add(AddBlockDto dto);
        void EditeBlookById(int id, UpdateBlockDto dto);
        List<GetAllBlookDto> GetAll();
        void AddBlockAndUnitRegistration(AddBlockAndUnitRegistrationDto dto);
    }
}

