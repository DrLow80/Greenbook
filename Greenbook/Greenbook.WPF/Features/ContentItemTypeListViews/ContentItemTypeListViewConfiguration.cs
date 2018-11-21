using Greenbook.ContentItemTypes;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.ContentItemTypeListViews
{
    [Configuration]
    public class ContentItemTypeListViewConfiguration : IApplicationContextAware
    {
        public IApplicationContext ApplicationContext { get; set; }

        [Definition]
        public virtual ContentItemsTypesHostViewModel ContentItemsTypesHostViewModel()
        {
            return new ContentItemsTypesHostViewModel();
        }

        [Definition]
        public virtual ContentItemTypeListViewModel ContentItemTypeListViewModel()
        {
            return new ContentItemTypeListViewModel(ContentItemTypesRepository());
        }

        [Definition]
        public virtual IContentItemTypesRepository ContentItemTypesRepository()
        {
            return ApplicationContext.GetObject<DataContext>();
        }
    }
}