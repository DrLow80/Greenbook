﻿using System;

namespace Greenbook.AhoCorasickTrie
{
    public class RootNode : BaseTrieNode
    {
        public RootNode()
            : base(string.Empty)
        {
        }

        public override bool IsRoot => true;

        public override BaseTrieNode Seek(char character)
        {
            if (char.IsUpper(character)) character = char.ToLowerInvariant(character);

            var result = CharacterNodes.TryGetValue(character, out var value);

            return result ? (BaseTrieNode) value : this;
        }

        public override void UpdateFailNode(BaseTrieNode baseNode)
        {
            throw new InvalidOperationException();
        }

        public override void UpdateTerm(string term)
        {
            throw new InvalidOperationException();
        }
    }
}