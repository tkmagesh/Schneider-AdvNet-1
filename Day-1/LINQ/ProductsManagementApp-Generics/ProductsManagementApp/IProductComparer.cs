namespace ProductsManagementApp
{
    /*public interface  IProductComparer
    {
        int Compare(Product left, Product right);
    }*/
    public interface IItemComparer<T>
    {
        int Compare(T left, T right);
    }
}