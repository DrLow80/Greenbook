using Greenbook.RandomTools;
using Greenbook.WPF.ContentItems;
using Greenbook.WPF.Sessions;

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

        public static SessionViewModel SessionViewModel =>
            SpringContext.GetObject<SessionViewModel>(nameof(SessionViewModel));

        public static SessionListViewModel SessionListViewModel =>
            SpringContext.GetObject<SessionListViewModel>(nameof(SessionListViewModel));

        public static SessionPrintViewModel SessionPrintViewModel =>
            SpringContext.GetObject<SessionPrintViewModel>(nameof(SessionPrintViewModel));

        public static HomeViewModel HomeViewModel => SpringContext.GetObject<HomeViewModel>(nameof(HomeViewModel));
    }
}