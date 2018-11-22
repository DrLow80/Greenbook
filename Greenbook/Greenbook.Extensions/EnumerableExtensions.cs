using System;
using System.Collections.Generic;
using System.Linq;

namespace Greenbook.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ClearAndLoad<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            collection.Clear();

            foreach (var item in enumerable) collection.Add(item);
        }

        public static IEnumerable<IEnumerable<T>> ToBatches<T>(this IEnumerable<T> collection, int batchSize)
        {
            if (collection.Count() < batchSize)
            {
                yield return collection;
            }
            else
            {
                var amount = Math.Ceiling((double)collection.Count() / batchSize);

                for (var i = 0; i < amount; i++)
                {
                    yield return collection.Skip(i * batchSize).Take(batchSize);
                }
            }
        }
    }
}