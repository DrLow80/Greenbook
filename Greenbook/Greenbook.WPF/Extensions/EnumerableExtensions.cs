using System.Collections.Generic;

namespace Greenbook.WPF.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ClearAndLoad<T>(this ICollection<T> observableCollection, IEnumerable<T> items)
        {
            observableCollection.Clear();

            foreach (var item in items) observableCollection.Add(item);
        }
    }
}