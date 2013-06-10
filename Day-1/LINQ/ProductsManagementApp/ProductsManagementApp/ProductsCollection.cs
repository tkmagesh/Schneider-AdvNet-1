using System.Collections;

namespace ProductsManagementApp
{
    public class ProductsCollection : IEnumerator, IEnumerable
    {
        private ArrayList _list = new ArrayList();

        public void Add(Product product)
        {
            _list.Add(product);
        }

        public Product Get(int index)
        {
            return (Product) _list[index];
        }

        //indexer syntax
        public Product this[int index]
        {
            get { return (Product) _list[index]; }
        }

        public Product GetById(int id)
        {
            foreach (var item in _list)
                if (((Product) item).Id == id) return (Product) item;
            return default(Product);
        }
        public int Count()
        {
            return _list.Count; 
        }
        public void Remove(int id)
        {
            for (int count = _list.Count, i = count - 1; i >= 0; i--)
            {
                if (((Product)_list[i] ).Id == id) _list.RemoveAt(i);
            }
        }

        private int index = -1;
        public bool MoveNext()
        {
            index++;
            if (index < _list.Count) return true;
            Reset();
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current { get { return _list[index]; } }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public void Sort()
        {
            for(var i=0;i<_list.Count-1;i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product) _list[i];
                    var right = (Product) _list[j];
                    if (left.Id > right.Id)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }

        public void Sort(IProductComparer comparer)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product)_list[i];
                    var right = (Product)_list[j];
                    if (comparer.Compare(left,right)  > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }

        public void Sort(CompareProductDelegate compareDelegate)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product)_list[i];
                    var right = (Product)_list[j];
                    if (compareDelegate(left, right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }

        public ProductsCollection Search(IProductSearchCriteria productSearchCriteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product) item;
                if (productSearchCriteria.isSatisfiedBy(product))
                    result.Add(product);
            }
            return result;
        }

        public ProductsCollection Search(ProductCriteriaDelegate criteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product)item;
                if (criteria(product))
                    result.Add(product);
            }
            return result;
        }

        public int Min(SelectIntAttributeDelegate selectAttribute)
        {
            var result = int.MaxValue;
            foreach (var item in _list)
            {
                var product = (Product) item;
                var productAttrValue = selectAttribute(product);
                if (result > productAttrValue)
                    result = productAttrValue;
            }
            return result;
        }
        public decimal Min(SelectDecimalAttributeDelegate selectAttribute)
        {
            var result = decimal.MaxValue;
            foreach (var item in _list)
            {
                var product = (Product)item;
                var productAttrValue = selectAttribute(product);
                if (result > productAttrValue)
                    result = productAttrValue;
            }
            return result;
        }
        //Min
        //Max
        //Average
        //Sum
        //Count(criteria)
        public int Count(CriteriaDelegate criteria)
        {
            var result = 0;
            foreach (var item in _list)
            {
                if (criteria((Product) item)) result++;
            }
            return result;
        }
        //All ( True if all the products satisfy a criteria or False if otherwise)
        public bool All(CriteriaDelegate criteria)
        {
            foreach (var item in _list)
            {
                if (!criteria((Product) item)) return false;
            }
            return true;
        }
        //Any ( True if atleast one of the products satisfy a criteria or False if otherwise)
        public bool Any(CriteriaDelegate criteria)
        {
            foreach (var item in _list)
            {
                if (criteria((Product)item)) return true;
            }
            return false;
        }
    }

    public delegate int SelectIntAttributeDelegate(Product product);
    public delegate decimal SelectDecimalAttributeDelegate(Product product);

    public delegate bool CriteriaDelegate(Product product);
}