using System.Collections.Generic;
using Greenbook.ContentItems;
using Greenbook.Entities;

namespace Greenbook.WPF.Features.ContentItems
{
    public class ContentItemsRepository : IContentItemsRepository
    {
        public IEnumerable<ContentItem> LoadContentItems()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomContentItem);
        }
    }
}