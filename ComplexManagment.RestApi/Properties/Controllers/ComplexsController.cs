using ComplexManagement.Services.Complexes.Contracts;
using ComplexManagement.Services.Complexes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexService _Service;
        public ComplexsController(ComplexService complexService)
        {
            _Service = complexService;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto)
        {
            _Service.Add(dto);
        }

        [HttpGet("{id}/block")]
        public GetComplexByIdWithBlocksDto GetById(int id)
        {
            return _Service.GetComplexByIdWithBlocksDto(id);
        }

        [HttpGet("{id}")]
        public GetComplexByIdDto GetComplexById([FromRoute]int id)
        {
            return _Service.GetById(id);
        }

        [HttpGet]
        public List<GetAllComplexByNameDto> GetAll([FromQuery]int id,string? name)
        {
           return _Service.GetAllSearchByName(id,name);
        }


        [HttpGet("{id}/usage-type")]
        public List<GetUsageTypeComplexDto> GetUsageType([FromRoute] int id)
        {
            return _Service.GetUsagetype(id);
        }

        [HttpPatch("{id}")]
        public void EditeComplexUnitCount([FromRoute] int id, [FromBody] int unitCount)
        {
           _Service.EditeUnitcount(id, unitCount);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            _Service.Delete(id);
        }

    }
}