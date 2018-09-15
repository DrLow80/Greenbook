using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Greenbook.Entities.AhoCorasick.Iterators
{
    public class SessionTrieIterator : ITrieIterator, IEnumerable<ContentItem>
    {
        private readonly IEnumerable<ContentItem> _contentItems;
        private readonly Session _session;

        private readonly List<ContentItem> _sessionContentItems = new List<ContentItem>();

        public SessionTrieIterator(Session session, IEnumerable<ContentItem> contentItems)
        {
            _session = session;
            _contentItems = contentItems;
        }

        public IEnumerator<ContentItem> GetEnumerator()
        {
            return _sessionContentItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Iterate(RootNode rootNode)
        {
            foreach (var encounter in _session.Encounters)
            {
                BaseTrieNode baseTrieNode = rootNode;

                foreach (var c in encounter.Description)
                {
                    baseTrieNode = baseTrieNode.Seek(c);

                    if (baseTrieNode.IsMatch)
                        AddMatchToResults(baseTrieNode.Fragment);
                }
            }
        }

        private void AddMatchToResults(string name)
        {
            var contentItem = _contentItems.FirstOrDefault(x =>
                x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contentItem != null && !_sessionContentItems.Contains(contentItem))
                _sessionContentItems.Add(contentItem);
        }
    }
}