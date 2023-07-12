using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Units;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers;

[Route("units")]
[ApiController]
public class UnitsController : Controller
{
    private readonly UnitRepository _unitRepository;
    private readonly BlockRepository _blockRepository;
    private readonly UnitOfWork _unitOfWork;

    public UnitsController(UnitRepository unitRepository,
        BlockRepository blockRepository,
        UnitOfWork unitOfWork)
    {
        _unitRepository = unitRepository;
        _blockRepository = blockRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public void Add(AddUnitDto dto)
    {
        var isExistBlockId = _blockRepository.CheckBlookId(dto.BlookId);
        if (!isExistBlockId)
        {
            throw new Exception("block not found");
        }

        var duplicateUnitName = _unitRepository.CheckDuplicateUnitNameAndId(dto.Name, dto.BlookId);
        if (duplicateUnitName)
        {
            throw new Exception("unit name duplicate");
        }

        var blockUnitCount = _unitRepository.GetBlockUnitCount(dto.BlookId);
        var totalUnitInBlock =_unitRepository.TotalUnitInBlock(dto.BlookId);

        if (totalUnitInBlock == blockUnitCount)
        {
            throw new Exception("unit count exception");
        }

        var unit = new Unit()
        {
            Name = dto.Name,
            BlookId = dto.BlookId,
            Resident = dto.Resident
        };

        _unitRepository.AddUnit(unit);
        _unitOfWork.Complit();
    }

    

}