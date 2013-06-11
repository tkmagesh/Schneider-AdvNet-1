namespace ProductsManagementApp
{
    public class Category : IHaveId
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}