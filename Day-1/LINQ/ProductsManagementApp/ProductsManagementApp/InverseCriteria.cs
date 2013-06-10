namespace ProductsManagementApp
{
    public class InverseCriteria : IProductSearchCriteria
    {
        private readonly IProductSearchCriteria _searchCriteria;

        public InverseCriteria(IProductSearchCriteria searchCriteria)
        {
            _searchCriteria = searchCriteria;
        }

        public bool isSatisfiedBy(Product product)
        {
            return !_searchCriteria.isSatisfiedBy(product);
        }
    }
}