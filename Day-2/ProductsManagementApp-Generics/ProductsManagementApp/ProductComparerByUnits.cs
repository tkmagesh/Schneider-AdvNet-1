namespace ProductsManagementApp
{
    public class ProductComparerByUnits : IItemComparer<Product>
    {
        public int Compare(Product left, Product right)
        {
            if (left.Units > right.Units)
                return 1;
            if (left.Units < right.Units)
                return -1;
            return 0;
        }
    }
}