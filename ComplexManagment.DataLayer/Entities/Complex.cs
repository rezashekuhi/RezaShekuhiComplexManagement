namespace ComplexManagment.DataLayer.Entities
{
    public class Complex
    {
        public Complex()
        {
            Blooks = new HashSet<Blook>();
           
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }

        public HashSet<Blook> Blooks { get; set; }
        

    }
}
