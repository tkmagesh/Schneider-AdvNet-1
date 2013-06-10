namespace ProductsManagementApp
{
    public class CheapProductSearchCriteria : IProductSearchCriteria
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