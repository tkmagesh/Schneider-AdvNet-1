namespace ProductsManagementApp
{
    public class Product : IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Units, Cost);
        }
    }
}