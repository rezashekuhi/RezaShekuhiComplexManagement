using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.UsageType;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.UsageTypes;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("usage-types")]
    [ApiController]
    public class UsageTypeController : Controller
    {
        private readonly UsageTypeRepository _usageTypeRepository;
        private readonly UnitOfWork _unitOfWork;

        public UsageTypeController(UsageTypeRepository usageTypeRepository,
            UnitOfWork unitOfWork)
        {
            _usageTypeRepository = usageTypeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void Add([FromBody]AddUsageTypeDto dto)
        {
            var isExistName = _usageTypeRepository.IsExistByName(dto.Title);
            if (isExistName)
            {
                throw new Exception("title is duplicate");
            }
            var usageType = new UsageType
            {
                Title = dto.Title
            };
            _usageTypeRepository.Add(usageType);
            _unitOfWork.Complit();
        }

        [HttpGet]
        public List<GetAllUsageType> GetAll()
        {
            return _usageTypeRepository.getAllUsageTypes();
        }

    }
}
