using System.Collections.Generic;
using Greenbook.Entities;

namespace Greenbook.ContentItemTypes
{
    public interface IContentItemTypesRepository
    {
        IEnumerable<ContentItemType> LoadContentItemTypes();
    }
}