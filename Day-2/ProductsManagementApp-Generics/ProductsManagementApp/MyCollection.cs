using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductsManagementApp
{
    public class MyCollection<T> : IEnumerator<T>, IEnumerable<T> where T : IHaveId
    {
        private ArrayList _list = new ArrayList();

        public void Add(T item)
        {
            _list.Add(item);
        }

        public T Get(int index)
        {
            return (T) _list[index];
        }

        //indexer syntax
        public T this[int index]
        {
            get { return (T) _list[index]; }
        }

       public T GetById(int id)
        {
            foreach (var item in _list)
                if (((T) item).Id == id) return (T) item;
            return default(T);
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
                    var left = (T) _list[i];
                    var right = (T) _list[j];
                    if (left.Id > right.Id)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }

        public void Sort(IItemComparer<T> comparer)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T)_list[i];
                    var right = (T)_list[j];
                    if (comparer.Compare(left,right)  > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }

        public void Sort(Func<T,T,int> compareDelegate)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T)_list[i];
                    var right = (T)_list[j];
                    if (compareDelegate(left, right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }




        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        T IEnumerator<T>.Current
        {
            get { return (T) this.Current; }
        }

        public void Dispose()
        {
            index = -1;
        }
    }
}