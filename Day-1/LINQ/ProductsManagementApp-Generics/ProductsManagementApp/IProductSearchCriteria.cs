namespace ProductsManagementApp
{
    public interface IItemSearchCriteria<T>
    {
        bool isSatisfiedBy(T item);
    }
}