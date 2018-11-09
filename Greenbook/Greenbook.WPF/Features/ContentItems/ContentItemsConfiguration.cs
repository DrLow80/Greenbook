using Greenbook.ContentItems;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.ContentItems
{
    [Configuration]
    public class ContentItemsConfiguration: IApplicationContextAware
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
            return ApplicationContext.GetObject<DataContext>();
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

        public IApplicationContext ApplicationContext { get; set; }
    }
}