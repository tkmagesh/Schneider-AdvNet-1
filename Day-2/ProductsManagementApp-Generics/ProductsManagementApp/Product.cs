namespace ProductsManagementApp
{
    public class Product : IHaveId, IFormat
    {
        [Format(true,1)]
        public int Id { get; set; }

        [Format(true,2)]
        public string Name { get; set; }

        [Format(true,3)]
        public int Units { get; set; }

        [Format(true,4)]
        public decimal Cost { get; set; }
        public override string ToString()
        {
            return this.Format("\t");
        }  
    }
}