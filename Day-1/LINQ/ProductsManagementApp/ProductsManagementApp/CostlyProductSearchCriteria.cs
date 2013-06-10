namespace ProductsManagementApp
{
    public class CostlyProductSearchCriteria : IProductSearchCriteria
    {
        private readonly decimal _cost;

        public CostlyProductSearchCriteria(decimal cost)
        {
            _cost = cost;
        }

        public bool isSatisfiedBy(Product product)
        {
            return product.Cost > _cost;
        }
    }
}