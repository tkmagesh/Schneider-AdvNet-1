namespace ProductsManagementApp
{
    public class ProductCategoryViewModel : IFormat
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
        public string CategoryName { get; set; }
    }
}