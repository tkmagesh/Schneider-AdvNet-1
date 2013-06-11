using System;
using System.Collections.Generic;

namespace ProductsManagementApp
{
    public static class MyCollectionUtils
    {
        public static IEnumerable<TResult> Join<T1, T2, TKey, TResult>(this IEnumerable<T1> list,
                                                                       IEnumerable<T2> joinList,
                                                                       Func<T1, TKey> sourceKeySelector,
                                                                       Func<T2, TKey> joinKeySelector,
                                                                       Func<T1, T2, TResult> joinOperation) where TKey : IComparable
        {
            foreach (var item in list)
            {
                var sourceKey = sourceKeySelector(item);
                foreach (var joinItem in joinList)
                {
                    var joinKey = joinKeySelector(joinItem);
                    if (sourceKey.CompareTo(joinKey) == 0)
                        yield return joinOperation(item, joinItem);
                }
            }
        } 

        public static Dictionary<TKey, IList<T>> GroupBy<T, TKey>(this IEnumerable<T> list,
                                                                         Func<T, TKey> keySelector)
        {
            var result = new Dictionary<TKey, IList<T>>();
            foreach (var item in list)
            {
                var itemKey = keySelector(item);
                if (!result.ContainsKey(itemKey))
                    result.Add(itemKey, new List<T>());
                result[itemKey].Add(item);
            }
            return result;
        } 
        public static bool Contains<T>(this IEnumerable<T> list, T obj)
        {
            foreach (var item in list)
            {
                if (item.Equals(obj)) return true;
            }
            return false;
        }
        public static bool Contains<T>(this IEnumerable<T> list, T obj, IEqualityComparer<T> comparer )
        {
            foreach (var item in list)
            {
                if (comparer.Equals(item,obj)) return true;
            }
            return false;
        }
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
        public static IEnumerable<TResult> Transform<T, TResult>(this IEnumerable<T> list,
                                                                 Func<T, TResult> transformation)
        {
            foreach (var item in list)
            {
                yield return transformation(item);
            }
        } 
        public static  IEnumerable<T> Search<T>(this IEnumerable<T> list, IItemSearchCriteria<T> productSearchCriteria)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (productSearchCriteria.isSatisfiedBy(tItem))
                    yield return tItem;
            }
        }

        public static IEnumerable<T> Search<T>(this IEnumerable<T> list, Func<T, bool> criteria)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria(tItem))
                    yield return tItem;
            }
        }

        public static int Min<T>(this IEnumerable<T> list, Func<T, int> selectAttribute)
        {
            var result = int.MaxValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var productAttrValue = selectAttribute(tItem);
                if (result > productAttrValue)
                    result = productAttrValue;
            }
            return result;
        }
        public static decimal Min<T>(this IEnumerable<T> list, Func<T, decimal> selectAttribute)
        {
            var result = decimal.MaxValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var productAttrValue = selectAttribute(tItem);
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
        public static int Count<T>(this IEnumerable<T> list, Func<T, bool> criteria)
        {
            var result = 0;
            foreach (var item in list)
            {
                if (criteria((T)item)) result++;
            }
            return result;
        }
        //All ( True if all the products satisfy a criteria or False if otherwise)
        public static bool All<T>(this IEnumerable<T> list, Func<T, bool> criteria)
        {
            foreach (var item in list)
            {
                if (!criteria((T)item)) return false;
            }
            return true;
        }
        //Any ( True if atleast one of the products satisfy a criteria or False if otherwise)
        public static bool Any<T>(this IEnumerable<T> list, Func<T, bool> criteria)
        {
            foreach (var item in list)
            {
                if (criteria((T)item)) return true;
            }
            return false;
        }
    }
}