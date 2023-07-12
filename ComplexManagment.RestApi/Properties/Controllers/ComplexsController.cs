using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Complexs;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexRepository _complexRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public ComplexsController(ComplexRepository complexRepository,
            BlockRepository blockRepository,
            UnitOfWork unitOfWork)
        {
            _complexRepository = complexRepository;
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public void Add([FromBody]AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };
            
            _complexRepository.Add(complex);
            _unitOfWork.Complit();
        }

        [HttpGet]
        public List<GetAllComplexByNameDto> GetAll([FromQuery]string? name)
        {
            return _complexRepository.GetAll(name);
        }
        
      
        [HttpGet("{id}/usage-type")]
        public List<GetUsageTypeComplexDto> GetUsageType([FromRoute]int id)
        {
            return _complexRepository.GetComplexOfUsagetype(id);

            
        }

        [HttpPatch]
        public void EditeComplexUnitCount([FromRoute]int id,[FromBody]int unitCount)
        {
          var complex= _complexRepository.GetById(id);
            var isExistComplexId=_complexRepository.IsExistsById(id);
            if (!isExistComplexId)
            {
                throw new Exception("Complex Not Found");
            }
            var unitcount = _complexRepository.GetUnitCountById(id);
            

            if (unitCount<unitcount)
            {
              List<Blook> blooks = _complexRepository.GetUnitCountBlookById(id);
                foreach (var item in blooks)
                {
                    item.UnitCount = 0;
                }
                _blockRepository.UpdateRange(blooks);
            }
            complex.UnitCount = unitcount;
            _complexRepository.Update(complex);
            _unitOfWork.Complit();
           
        }
    }
} 