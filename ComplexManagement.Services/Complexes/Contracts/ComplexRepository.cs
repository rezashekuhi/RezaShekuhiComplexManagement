using ComplexManagement.Services.Complexes.Dto;
using ComplexManagment.Entities;
using System.Numerics;
using Complex = ComplexManagment.Entities.Complex;

namespace ComplexManagement.Services.Complexes;

public interface ComplexRepository
{
    void Add(Complex complex);
    List<GetAllComplexByNameDto> GetAll(int id,string? searchName);
    bool IsExistsById(int id);
    int GetUnitCountById(int id);
    List<GetUsageTypeComplexDto> GetComplexOfUsagetype(int id);
    List<Blook> GetUnitCountBlookById(int id);
    Complex FindeById(int id);
    void Update(Complex complex);
    GetComplexByIdWithBlocksDto GetComplexByIdWithBlocksDto(int id);
    GetComplexByIdDto FindComplexById(int id);
    bool CheckToHaveAUnit(int id);
    void Delete(Complex complex);    
}