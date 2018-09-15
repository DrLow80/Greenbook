using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System.Text;

namespace Greenbook.Entities.AhoCorasick.Iterators
{
    public class BuildAhoCorasickMapBranchIterator : ITrieIterator
    {
        private readonly string term;

        public BuildAhoCorasickMapBranchIterator(string term)
        {
            Guard.ArgumentNotNull(term, nameof(term));

            this.term = term.ToLowerInvariant();
        }

        public void Iterate(RootNode rootNode)
        {
            Guard.ArgumentNotNull(rootNode, nameof(rootNode));

            var stringBuilder = new StringBuilder();

            BaseTrieNode cursor = rootNode;

            foreach (var character in term)
            {
                stringBuilder.Append(character);

                var result = cursor.CharacterNodes.ContainsKey(character);

                if (!result) cursor.CharacterNodes[character] = new CharacterNode(stringBuilder.ToString(), cursor);

                cursor = cursor.Seek(character);
            }

            cursor.UpdateTerm(term);
        }
    }
}