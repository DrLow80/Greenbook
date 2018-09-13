using System.Collections;
using System.Collections.Generic;

namespace Greenbook.Entities
{
    public class ContentNameParser : IEnumerable<ContentName>
    {
        private readonly string _value;

        public ContentNameParser(string value)
        {
            this._value = value;
        }

        public IEnumerator<ContentName> GetEnumerator()
        {
            var names = _value.Split(' ');

            foreach (var name in names)
            {
                var result = ContentName.Create(name);

                if (result.IsSuccess)
                {
                    yield return result.Value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}