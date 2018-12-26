using Greenbook.ContentItems.Views;
using Greenbook.Domain;
using Greenbook.Foundation.DependencyInjection;

namespace Greenbook.ContentItems
{
    public class ViewModelLocator
    {
        public static HostViewModel HostViewModel =>
            SpringContext.GetObject<HostViewModel>(nameof(HostViewModel));

        public static ListViewModel ListViewModel =>
            SpringContext.GetObject<ListViewModel>(nameof(Views.ListViewModel));

        public static ContentItemViewModel ContentItemViewModel =>
            SpringContext.GetObject<ContentItemViewModel>(nameof(ContentItemViewModel));
    }
}