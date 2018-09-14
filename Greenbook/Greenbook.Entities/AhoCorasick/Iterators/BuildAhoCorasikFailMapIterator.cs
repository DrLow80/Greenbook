using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick.Iterators
{
    public class BuildAhoCorasikFailMapIterator : ITrieIterator
    {
        private readonly Trie trie;

        public BuildAhoCorasikFailMapIterator(Trie trie)
        {
            Guard.ArgumentNotNull(trie, nameof(trie));

            this.trie = trie;
        }

        public void Iterate(RootNode rootNode)
        {
            Guard.ArgumentNotNull(rootNode, nameof(rootNode));

            foreach (var node in rootNode)
            {
                this.UpdateFailNodeForEachFragment(node);
            }
        }

        private void UpdateFailNodeForEachFragment(BaseTrieNode baseNode)
        {
            foreach (var fragment in GetFragments(baseNode.Fragment))
            {
                this.UpdateFailNodeIfNotRootOrSelf(fragment, baseNode);
            }
        }

        private void UpdateFailNodeIfNotRootOrSelf(string fragment, BaseTrieNode baseNode)
        {
            var failNode = this.trie.Find(fragment);

            if (!failNode.IsRoot && failNode != baseNode)
            {
                baseNode.UpdateFailNode(failNode);
            }
        }

        private static IEnumerable<string> GetFragments(string value)
        {
            while (value.Any())
            {
                yield return value;

                value = value.Substring(1);
            }
        }
    }
}