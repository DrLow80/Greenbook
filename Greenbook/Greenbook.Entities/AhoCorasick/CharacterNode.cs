using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick
{
    public class CharacterNode : BaseTrieNode
    {
        public CharacterNode(string fragment, BaseTrieNode baseNode)
            : base(fragment)
        {
            Guard.ArgumentNotNull(baseNode, nameof(baseNode));

            FailNode = baseNode;
        }

        public override BaseTrieNode Seek(char character)
        {
            if (char.IsUpper(character)) character = char.ToLowerInvariant(character);

            var result = CharacterNodes.TryGetValue(character, out var value);

            var node = result ? value : FailNode.Seek(character);

            return node;
        }
    }
}