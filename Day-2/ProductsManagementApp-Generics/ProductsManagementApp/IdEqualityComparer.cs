using System.Collections.Generic;

namespace ProductsManagementApp
{
    public class IdEqualityComparer<T> : IEqualityComparer<T> where T : IHaveId
    {
        public bool Equals(T x, T y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }

    }
}