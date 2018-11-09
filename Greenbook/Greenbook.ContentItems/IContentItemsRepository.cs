using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public interface IContentItemsRepository
    {
        IEnumerable<ContentItem> LoadContentItems();

        Result<string> SelectImage();
        IEnumerable<ContentItemType> LoadContentItemTypes();
        Result Insert(ContentItem contentItem);

        Result Remove(ContentItem contentItem);
    }
}