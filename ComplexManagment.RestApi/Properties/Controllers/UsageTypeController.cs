using ComplexManagement.Services.UsageTypes.Contract;
using ComplexManagement.Services.UsageTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("usage-types")]
    [ApiController]
    public class UsageTypeController : Controller
    {
        private readonly UsageTypeService _usageTypeService;
        public UsageTypeController(UsageTypeService usageTypeService)
        {
            _usageTypeService = usageTypeService;
        }

        [HttpPost]
        public void Add([FromBody]AddUsageTypeDto dto)
        {
            _usageTypeService.Add(dto);
        }

        [HttpGet]
        public List<GetAllUsageType> GetAll()
        {
           return _usageTypeService.GetAll();
        }

    }
}
