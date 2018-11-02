using System.Collections.Generic;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public interface IContentItemsRepository
    {
        IEnumerable<ContentItem> LoadContentItems();
    }
}