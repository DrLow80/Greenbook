using System.Collections.Generic;

namespace Greenbook.Entities
{
    public class ContentItem : BaseEntity
    {
        public List<Encounter> Encounters { get; set; } = new List<Encounter>();

        public string ImageSource { get; set; }

        public ContentItemType ContentType { get; set; }
    }
}