namespace ProductsManagementApp
{
    public class CheapProductSearchCriteria : IItemSearchCriteria<Product>
    {
        private readonly decimal _cost;

        public CheapProductSearchCriteria(decimal cost)
        {
            _cost = cost;
        }

        public bool isSatisfiedBy(Product product)
        {
            return product.Cost <= _cost;
        }
    }
}