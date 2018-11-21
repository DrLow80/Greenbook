using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Greenbook.AhoCorasickTrie;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class SessionTrieIterator : ITrieIterator, IEnumerable<ContentItem>
    {
        private readonly List<ContentItem> _contentItems = new List<ContentItem>();
        private readonly IDictionary<string, ContentItem> _dictionary;
        private readonly Session _session;

        public SessionTrieIterator(Session session, IEnumerable<ContentItem> contentItems)
        {
            _session = session;
            _dictionary = contentItems.ToDictionary(x => x.Name);
        }

        public IEnumerator<ContentItem> GetEnumerator()
        {
            return _contentItems.Distinct().OrderBy(x => x.Name).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Iterate(RootNode rootNode)
        {
            foreach (var encounter in _session.Encounters.Where(x => !string.IsNullOrEmpty(x.Description)))
            {
                BaseTrieNode cursor = rootNode;

                foreach (var c in encounter.Description)
                {
                    cursor = cursor.Seek(c);

                    if (!cursor.IsMatch) continue;

                    var contentItem = _dictionary[cursor.Term];

                    _contentItems.Add(contentItem);
                }
            }
        }
    }
}