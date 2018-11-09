using Greenbook.Domain;

namespace Greenbook.ContentItemTypes
{
    public class ViewModelLocator
    {
        public static ContentItemsTypesHostViewModel ContentItemsTypesHostViewModel =>
            SpringContext.GetObject<ContentItemsTypesHostViewModel>(nameof(ContentItemsTypesHostViewModel));
    }
}