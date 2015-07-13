using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomLINQ
{
    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var coll in collection)
            {
                if (predicate(coll))
                {
                    yield return coll;
                }
            }
        }

        public static IEnumerable<T> WhereNot1<T>(this IEnumerable<T> collections, Predicate<T> filterPredicate)
        {
            foreach (var collection in collections)
            {
                if (!filterPredicate(collection))
                {
                    yield return collection;
                }
            }
        }
        public static IEnumerable<T> WhereNot2<T>(this IEnumerable<T> collections, Predicate<T> filterPredicate)
        {
            List<T> matchList = new List<T>();
            foreach (var collection in collections)
            {
                if (!filterPredicate(collection))
                {
                    matchList.Add(collection);
                }
            }
            return matchList;
        }

        public static TSelector Maxi<TSource, TSelector>(this IEnumerable<TSource> collections ,Func<TSource,TSelector> filterPredicat) where TSelector : IComparable
        {
            TSelector max = filterPredicat(collections.First());
            foreach (var collection in collections)
            {
                if (max.CompareTo(filterPredicat(collection)) < 0)
                {
                    max = filterPredicat(collection);
                }

            }
            return max;
        }
    }
}