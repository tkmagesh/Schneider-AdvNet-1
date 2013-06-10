namespace ProductsManagementApp
{
    public interface IProductSearchCriteria
    {
        bool isSatisfiedBy(Product product);
    }
}