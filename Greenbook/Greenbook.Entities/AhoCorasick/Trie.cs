using Greenbook.Entities.AhoCorasick.Iterators;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick
{
    public class Trie
    {
        private readonly RootNode _rootNode = new RootNode();

        public Trie(params string[] terms)
        {
            foreach (var term in terms)
            {
                this.Iterate(new BuildAhoCorasickMapBranchIterator(term));
            }

            this.Iterate(new BuildAhoCorasikFailMapIterator(this));
        }

        public BaseTrieNode Find(string value)
        {
            Guard.ArgumentNotNull(value, nameof(value));

            var ahoCorasickIterator = new FindAhoCorasickIterator(value);

            this.Iterate(ahoCorasickIterator);

            return ahoCorasickIterator.Cursor;
        }

        public void Iterate(ITrieIterator trieIterator)
        {
            Guard.ArgumentNotNull(trieIterator, nameof(trieIterator));

            trieIterator.Iterate(this._rootNode);
        }
    }
}