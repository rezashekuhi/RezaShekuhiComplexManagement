namespace ComplexManagment.DataLayer.Dto.Complexs;

public class GetComplexByIdWithBlocksDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GetBlockDto> Blocks { get; set; }
}

public class GetBlockDto
{
    public int? BlockId { get; set; }
    public string BlockName { get; set; }
    public int? BlockUnitCount { get; set; }
    public int UnitRegisteredCount { get; set; }
}