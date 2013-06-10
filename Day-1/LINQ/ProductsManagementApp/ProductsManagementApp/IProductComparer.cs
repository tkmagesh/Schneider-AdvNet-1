namespace ProductsManagementApp
{
    public interface  IProductComparer
    {
        int Compare(Product left, Product right);
    }
}