using Greenbook.WPF.ContentItems;

namespace Greenbook.WPF
{
    public class ViewModelLocator
    {
        public static ApplicationViewModel ApplicationViewModel =>
            SpringContext.GetObject<ApplicationViewModel>(nameof(ApplicationViewModel));

        public static ContentItemListViewModel ContentItemListViewModel =>
            SpringContext.GetObject<ContentItemListViewModel>(nameof(ContentItemListViewModel));

        public static DataViewModel DataViewModel => SpringContext.GetObject<DataViewModel>(nameof(DataViewModel));

        public static ContentItemViewModel ContentItemViewModel =>
            SpringContext.GetObject<ContentItemViewModel>(nameof(ContentItemViewModel));
    }
}