using Greenbook.Domain;

namespace Greenbook.ContentItems
{
    public class ViewModelLocator
    {
        public static ContentItemsHostViewModel ContentItemsHostViewModel =>
            SpringContext.GetObject<ContentItemsHostViewModel>(nameof(ContentItemsHostViewModel));

        public static ContentItemListViewModel ContentItemListViewModel =>
            SpringContext.GetObject<ContentItemListViewModel>(nameof(ContentItemListViewModel));

        public static ContentItemViewModel ContentItemViewModel =>
            SpringContext.GetObject<ContentItemViewModel>(nameof(ContentItemViewModel));

        public static ContentItemTypesViewModel ContentItemTypesViewModel =>
            SpringContext.GetObject<ContentItemTypesViewModel>(nameof(ContentItemTypesViewModel));

    }
}