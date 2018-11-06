using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class ContentItemsByTypeGroup : IGrouping<string, ContentItem>
    {
        private IEnumerable<ContentItem> _contentItems;

        public ContentItemsByTypeGroup(string key, IEnumerable<ContentItem> contentItems)
        {
            Key = key;
            _contentItems = contentItems;
        }


        public IEnumerator<ContentItem> GetEnumerator()
        {
            return _contentItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Key { get; }
    }
}