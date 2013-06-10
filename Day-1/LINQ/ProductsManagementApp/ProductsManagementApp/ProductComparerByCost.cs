namespace ProductsManagementApp
{
    public class ProductComparerByCost : IProductComparer
    {
        public int Compare(Product left, Product right)
        {
            if (left.Cost > right.Cost)
                return 1;
            if (left.Cost < right.Cost)
                return -1;
            return 0;

        }
    }
}