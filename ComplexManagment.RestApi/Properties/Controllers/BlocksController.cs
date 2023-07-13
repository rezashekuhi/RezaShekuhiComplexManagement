using ComplexManagement.Services.Blooks.Contract;
using ComplexManagement.Services.Blooks.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Properties.Controllers;

[Route("blocks")]
[ApiController]
public class BlocksController : Controller
{

    private readonly BlookService _service;
    public BlocksController(BlookService blookService)
    {
        _service = blookService;
    }
    [HttpPost("unit-add")]
    public void AddBlookWhithUnit(AddBlockAndUnitRegistrationDto dto)
    {
        _service.AddBlockAndUnitRegistration(dto);
    }

    [HttpPost]
    public void Add(AddBlockDto dto)
    {
       _service.Add(dto);
    }

    [HttpPatch("{id}")]
    public void Update([FromRoute] int id, [FromBody] UpdateBlockDto dto)
    {
        _service.EditeBlookById(id,dto);
    }

    [HttpGet]
    public List<GetAllBlookDto> GetAll()
    {
       return _service.GetAll();
    }
}