
using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public interface ComplexRepository
{
    void Add(Complex complex);
    List<GetAllComplexByNameDto> GetAll(string? searchName);
    bool IsExistsById(int id);
    int GetUnitCountById(int id);
    List<GetUsageTypeComplexDto> GetComplexOfUsagetype(int id);
    List<Blook> GetUnitCountBlookById(int id);
    Complex GetById(int id);
    void Update(Complex complex);
}