using ComplexManagement.Services.Blooks;
using ComplexManagement.Services.Complexes.Dto;
using ComplexManagment.Entities;

namespace ComplexManagement.Services.Complexes.Contracts
{
    public class ComplexAppService : ComplexService
    {
        private readonly ComplexRepository _complexRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public ComplexAppService(ComplexRepository complexRepository,
            BlockRepository blockRepository,
            UnitOfWork unitOfWork)
        {
            _complexRepository = complexRepository;
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };

            _complexRepository.Add(complex);
            _unitOfWork.Complit();
        }

        public void EditeUnitcount(int id, int unitCount)
        {
            var complex = _complexRepository.GetById(id);
            var isExistComplexId = _complexRepository.IsExistsById(id);
            if (!isExistComplexId)
            {
                throw new Exception("Complex Not Found");
            }



            if (unitCount < complex.UnitCount)
            {
                List<Blook> blooks = _complexRepository.GetUnitCountBlookById(id);
                foreach (var item in blooks)
                {
                    item.UnitCount = 0;
                }
                _blockRepository.UpdateRange(blooks);
            }
            complex.UnitCount = unitCount;
            _complexRepository.Update(complex);
            _unitOfWork.Complit();
        }

        public List<GetAllComplexByNameDto> GetAllSearchByName(string? name)
        {
            return _complexRepository.GetAll(name);
        }

        public GetComplexByIdWithBlocksDto GetComplexByIdWithBlocksDto(int id)
        {

            return _complexRepository.GetComplexByIdWithBlocksDto(id); 
            
        }

        public List<GetUsageTypeComplexDto> GetUsagetype(int id)
        {
            return _complexRepository.GetComplexOfUsagetype(id);
        }
    }
}
