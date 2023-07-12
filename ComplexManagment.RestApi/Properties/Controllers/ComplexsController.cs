using ComplexManagement.Services.Complexes.Contracts;
using ComplexManagement.Services.Complexes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexService _complexService;
        public ComplexsController(ComplexService complexService)
        {
            _complexService = complexService;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto)
        {
            _complexService.Add(dto);
        }

        [HttpGet("{id}/block")]
        public GetComplexByIdWithBlocksDto GetById(int id)
        {
            return _complexService.GetComplexByIdWithBlocksDto(id);
        }

        [HttpGet]
        public List<GetAllComplexByNameDto> GetAll([FromQuery] string? name)
        {
           return _complexService.GetAllSearchByName(name);
        }


        [HttpGet("{id}/usage-type")]
        public List<GetUsageTypeComplexDto> GetUsageType([FromRoute] int id)
        {
            return _complexService.GetUsagetype(id);
        }

        [HttpPatch("{id}")]
        public void EditeComplexUnitCount([FromRoute] int id, [FromBody] int unitCount)
        {
           _complexService.EditeUnitcount(id, unitCount);
        }
    }
}