using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Greenbook.Entities.AhoCorasick
{
    public abstract class BaseTrieNode : IEnumerable<BaseTrieNode>
    {
        public readonly Dictionary<char, CharacterNode> CharacterNodes =
            new Dictionary<char, CharacterNode>();

        protected BaseTrieNode(string fragment)
        {
            Guard.ArgumentNotNull(fragment, nameof(fragment));

            this.Fragment = fragment;
        }

        public BaseTrieNode FailNode { get; protected set; }

        public string Fragment { get; }

        public bool IsMatch => !string.IsNullOrEmpty(this.Term);

        public string Term { get; protected set; }

        public virtual bool IsRoot => false;

        public IEnumerator<BaseTrieNode> GetEnumerator()
        {
            foreach (var characterNode in this.CharacterNodes.Values)
            {
                yield return characterNode;

                foreach (var childNode in characterNode)
                {
                    yield return childNode;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public abstract BaseTrieNode Seek(char character);

        public virtual void UpdateFailNode(BaseTrieNode baseNode)
        {
            Guard.ArgumentNotNull(baseNode, nameof(baseNode));

            this.FailNode = baseNode;
        }

        public virtual void UpdateTerm(string term)
        {
            Guard.ArgumentNotNullOrEmpty(term, nameof(term));

            this.Term = term;
        }
    }
}