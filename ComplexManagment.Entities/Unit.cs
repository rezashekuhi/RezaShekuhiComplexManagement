namespace ComplexManagment.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlookId { get; set; }
        public Blook Blook { get; set; }
        public UnitType Resident { get; set; }
    }
    public enum UnitType
    {
        malek = 1,
        mostager = 2,
        khali = 3
    }
}
