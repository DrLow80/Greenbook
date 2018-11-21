using System.Collections.Generic;

namespace Greenbook.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ClearAndLoad<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            collection.Clear();

            foreach (var item in enumerable) collection.Add(item);
        }
    }
}