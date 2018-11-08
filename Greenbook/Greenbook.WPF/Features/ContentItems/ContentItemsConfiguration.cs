using Greenbook.ContentItems;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.ContentItems
{
    [Configuration]
    public class ContentItemsConfiguration
    {
        [Definition]
        public virtual ContentItemsHostViewModel ContentItemsHostViewModel()
        {
            return new ContentItemsHostViewModel();
        }

        [Definition]
        public virtual ContentItemListViewModel ContentItemListViewModel()
        {
            return new ContentItemListViewModel(ContentItemsRepository());
        }

        [Definition]
        public virtual IContentItemsRepository ContentItemsRepository()
        {
            return new ContentItemsRepository();
        }

        [Definition]
        public virtual ContentItemViewModel ContentItemViewModel()
        {
            return new ContentItemViewModel(ContentItemsRepository());
        }

        [Definition]
        public virtual ContentItemTypesViewModel ContentItemTypesViewModel()
        {
            return new ContentItemTypesViewModel(ContentItemsRepository());
        }
    }
}