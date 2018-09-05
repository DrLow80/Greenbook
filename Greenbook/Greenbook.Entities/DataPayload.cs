using System.Collections.Generic;

namespace Greenbook.Entities
{
    public class DataPayload
    {
        public DataPayload()
        {
            ContentItems = RandomUtilities.RandomList(3, 5, RandomUtilities.RandomContentItem);
            ContentItemTypes = new[] { "Test", "Test 2" };
        }

        public IEnumerable<ContentItem> ContentItems { get; }
        public IEnumerable<string> ContentItemTypes { get; }
    }
}