using System.Collections.Generic;

namespace Greenbook.Entities
{
    public class DataPayload
    {
        public DataPayload()
        {
            ContentItems = RandomUtilities.RandomList(3, 5, RandomUtilities.RandomContentItem);
        }

        public IEnumerable<ContentItem> ContentItems { get; }
    }
}