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
            return ApplicationContext.GetObject<ProjectRepository>();
        }

        [Definition]
        public virtual ContentItemViewModel ContentItemViewModel()
        {
            var contentItemViewModel = new ContentItemViewModel(ContentItemsRepository());

            contentItemViewModel.CreateCommand = new ContentItemViewModelCreateCommand(contentItemViewModel, ContentItemsRepository());

            contentItemViewModel.RemoveCommand = new ContentItemViewModelRemoveCommand(contentItemViewModel, ContentItemsRepository());

            return contentItemViewModel;
        }
    }
}