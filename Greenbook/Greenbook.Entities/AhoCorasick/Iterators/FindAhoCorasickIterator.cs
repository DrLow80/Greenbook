using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick.Iterators
{
    public class FindAhoCorasickIterator : ITrieIterator
    {
        private readonly string term;

        public FindAhoCorasickIterator(string term)
        {
            Guard.ArgumentNotNull(term, nameof(term));

            this.term = term;
        }

        public BaseTrieNode Cursor { get; private set; }

        public void Iterate(RootNode rootNode)
        {
            Guard.ArgumentNotNull(rootNode, nameof(rootNode));

            this.Cursor = rootNode;

            foreach (var chracter in this.term)
            {
                this.Cursor = this.Cursor.Seek(chracter);
            }
        }
    }
}