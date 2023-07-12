namespace ComplexManagment.DataLayer.Dto.Complexs;

public class GetAllComplexByNameDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfRegisteredUnits { get; set; }
    public int NumberOfUnregisteredUnits { get; set; }
}