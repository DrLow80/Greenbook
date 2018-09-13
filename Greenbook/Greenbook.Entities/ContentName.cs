using CSharpFunctionalExtensions;

namespace Greenbook.Entities
{
    public class ContentName
    {
        private ContentName(string raw)
        {
            Raw = raw;
        }

        public string Name => Raw.Substring(1);

        public const string FailNameNullOrEmpty = "FailNameNullOrEmpty";

        public const string FailNotLinkedName = "FailNotLinkedName";

        public string LowerName => Name.ToLowerInvariant();

        public string Raw { get; }

        public static Result<ContentName> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Result.Fail<ContentName>(FailNameNullOrEmpty);
            }

            if (!value.StartsWith("@"))
            {
                return Result.Fail<ContentName>(FailNotLinkedName);
            }

            var contentName = new ContentName(value);

            return Result.Ok(contentName);
        }
    }
}