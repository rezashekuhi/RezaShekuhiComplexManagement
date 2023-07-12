using ComplexManagement.Services;
using ComplexManagement.Services.Blooks;
using ComplexManagement.Services.units;
using ComplexManagement.Services.units.Contact;
using ComplexManagement.Services.units.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers;

[Route("units")]
[ApiController]
public class UnitsController : Controller
{
    private readonly UnitService _unitService;
    public UnitsController(UnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpPost]
    public void Add(AddUnitDto dto)
    {
        _unitService.Add(dto);
    }
}