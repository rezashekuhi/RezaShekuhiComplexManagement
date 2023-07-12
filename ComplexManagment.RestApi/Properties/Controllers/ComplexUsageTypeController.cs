using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.ComplexUsageType;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Complexs;
using ComplexManagment.DataLayer.Repositories.ComplexUsageTypes;
using ComplexManagment.DataLayer.Repositories.UsageTypes;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("complex-usage-type")]
    [ApiController]
    public class ComplexUsageTypeController : Controller
    {
        private readonly ComplexUsageTypeRepository _complexUsageTypeRepository;
        private readonly ComplexRepository _complexRepository;
        private readonly UsageTypeRepository _usageTypeRepository;
        private readonly UnitOfWork _unitOfWork;

        public ComplexUsageTypeController(ComplexUsageTypeRepository complexUsageTypeRepository,
            ComplexRepository complexRepository,
            UsageTypeRepository usageTypeRepository,
            UnitOfWork unitOfWork)
        {
            _complexUsageTypeRepository = complexUsageTypeRepository;
            _complexRepository = complexRepository;
            _usageTypeRepository = usageTypeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void Add(AddComplexUsageTypeDto dto)
        {
            var isExistComplexId=_complexRepository.IsExistsById(dto.ComplexId);
            if (!isExistComplexId)
            {
                throw new Exception("Complex Id is not found");
            }

            var isExistUsageTypeId = _usageTypeRepository.IsExistById(dto.UsageTypeId);
            if (!isExistUsageTypeId)
            {
                throw new Exception("UsageType Id is not found");
            }

            var isDuplicate=_complexUsageTypeRepository.IsduplicateId(dto.ComplexId, dto.UsageTypeId);
            if (isDuplicate)
            {
                throw new Exception("ComplexId Or UsageTypeId Is Duplicate");
            }
            var complexUsageType = new ComplexUsageType
            {
                ComplexId = dto.ComplexId,
                UsageTypeId = dto.UsageTypeId
            };
            _complexUsageTypeRepository.Add(complexUsageType);
            _unitOfWork.Complit();
        }


    }
}
