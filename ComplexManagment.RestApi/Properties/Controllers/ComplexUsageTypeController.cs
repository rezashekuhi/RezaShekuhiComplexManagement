using ComplexManagement.Services;
using ComplexManagement.Services.Complexes;
using ComplexManagement.Services.ComplexUsageTypes;
using ComplexManagement.Services.ComplexUsageTypes.Contact;
using ComplexManagement.Services.ComplexUsageTypes.Dto;
using ComplexManagement.Services.UsageTypes;
using ComplexManagment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers
{
    [Route("complex-usage-type")]
    [ApiController]
    public class ComplexUsageTypeController : Controller
    {

        private readonly ComplexUsageTypeService _complexUsageTypeService;
        public ComplexUsageTypeController(ComplexUsageTypeService complexUsageTypeService)
        {
            _complexUsageTypeService = complexUsageTypeService;
        }

        [HttpPost]
        public void Add(AddComplexUsageTypeDto dto)
        {
            _complexUsageTypeService.Add(dto);
        }


    }
}
