using Greenbook.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Greenbook.Data
{
    public class DataPayload
    {
        public DataPayload()
        {
            ContentItemTypes = RandomUtilities.RandomList(5, 5, RandomUtilities.RandomContentItemType).ToArray();

            ContentItems = RandomUtilities.RandomList(3, 5, RandomUtilities.RandomContentItem).ToArray();

            foreach (var contentItem in ContentItems)
            {
                contentItem.ContentType = RandomUtilities.OneRandom(ContentItemTypes);
            }

            Sessions = RandomUtilities.RandomList(3, 5, RandomUtilities.RandomSession);

            var contentEncounters = ContentItems.SelectMany(x => x.Encounters).ToArray();

            foreach (var session in Sessions)
            {
                session.Encounters.Add(RandomUtilities.OneRandom(contentEncounters));
            }
        }

        public IEnumerable<ContentItem> ContentItems { get; }

        public ContentItemType[] ContentItemTypes { get; }

        public IEnumerable<Session> Sessions { get; }
    }
}