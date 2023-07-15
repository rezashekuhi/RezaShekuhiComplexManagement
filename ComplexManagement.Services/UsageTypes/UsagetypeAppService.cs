using ComplexManagement.Services.UsageTypes.Dto;
using ComplexManagement.Services.UsageTypes.Exeptions;
using ComplexManagment.Entities;

namespace ComplexManagement.Services.UsageTypes.Contract
{
    public class UsagetypeAppService : UsageTypeService
    {
        private readonly UsageTypeRepository _usageTypeRepository;
        private readonly UnitOfWork _unitOfWork;

        public UsagetypeAppService(UsageTypeRepository usageTypeRepository,
            UnitOfWork unitOfWork)
        {
            _usageTypeRepository = usageTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddUsageTypeDto dto)
        {
            var isExistName = _usageTypeRepository.IsExistByName(dto.Title);
            if (isExistName)
            {
                throw new TitleIsDuplicateException();
            }
            var usageType = new UsageType
            {
                Title = dto.Title
            };
            _usageTypeRepository.Add(usageType);
            _unitOfWork.Complit();
        }

        public List<GetAllUsageType> GetAll()
        {
            return _usageTypeRepository.getAllUsageTypes();
        }
    }
}
