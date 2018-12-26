using Greenbook.Domain;
using Greenbook.Foundation.DependencyInjection;

namespace Greenbook.ContentItemTypes
{
    public class ViewModelLocator
    {
        public static ContentItemsTypesHostViewModel ContentItemsTypesHostViewModel =>
            SpringContext.GetObject<ContentItemsTypesHostViewModel>(nameof(ContentItemsTypesHostViewModel));
    }
}