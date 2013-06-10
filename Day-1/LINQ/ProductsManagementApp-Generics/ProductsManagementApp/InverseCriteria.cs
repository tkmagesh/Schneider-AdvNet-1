namespace ProductsManagementApp
{
    public class InverseCriteria<T> : IItemSearchCriteria<T>
    {
        private readonly IItemSearchCriteria<T> _searchCriteria;

        public InverseCriteria(IItemSearchCriteria<T> searchCriteria)
        {
            _searchCriteria = searchCriteria;
        }

        public bool isSatisfiedBy(T item)
        {
            return !_searchCriteria.isSatisfiedBy(item);
        }
    }
}