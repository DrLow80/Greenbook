using Greenbook.ContentItems;
using Greenbook.ContentItems.Views;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.ContentItems
{
    [Configuration]
    public class ContentItemsConfiguration : IApplicationContextAware
    {
        public IApplicationContext ApplicationContext { get; set; }

        [Definition]
        public virtual HostViewModel HostViewModel()
        {
            return new HostViewModel();
        }

        [Definition]
        public virtual ListViewModel ListViewModel()
        {
            return new ListViewModel(ContentItemsRepository());
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
    }
}