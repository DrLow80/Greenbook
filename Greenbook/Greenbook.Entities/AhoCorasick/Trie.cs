using Greenbook.Entities.AhoCorasick.Iterators;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick
{
    public class Trie
    {
        private readonly RootNode _rootNode = new RootNode();

        public Trie(params string[] terms)
        {
            foreach (var term in terms) Iterate(new BuildAhoCorasickMapBranchIterator(term));

            Iterate(new BuildAhoCorasikFailMapIterator(this));
        }

        public BaseTrieNode Find(string value)
        {
            Guard.ArgumentNotNull(value, nameof(value));

            var ahoCorasickIterator = new FindAhoCorasickIterator(value);

            Iterate(ahoCorasickIterator);

            return ahoCorasickIterator.Cursor;
        }

        public void Iterate(ITrieIterator trieIterator)
        {
            Guard.ArgumentNotNull(trieIterator, nameof(trieIterator));

            trieIterator.Iterate(_rootNode);
        }
    }
}