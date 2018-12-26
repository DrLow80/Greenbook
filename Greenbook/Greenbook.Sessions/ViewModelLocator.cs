using Greenbook.Domain;
using Greenbook.Foundation.DependencyInjection;
using Greenbook.Sessions.Views;

namespace Greenbook.Sessions
{
    public class ViewModelLocator
    {
        public static HostSessionViewModel HostSessionViewModel =>
            SpringContext.GetObject<HostSessionViewModel>(nameof(HostSessionViewModel));

        public static ListSessionsViewModel ListSessionsViewModel =>
            SpringContext.GetObject<ListSessionsViewModel>(nameof(ListSessionsViewModel));

        public static SessionViewModel SessionViewModel =>
            SpringContext.GetObject<SessionViewModel>(nameof(SessionViewModel));

        public static ContentItemsViewModel ContentItemsViewModel =>
            SpringContext.GetObject<ContentItemsViewModel>(nameof(ContentItemsViewModel));

        public static PrintViewModel PrintViewModel => SpringContext.GetObject<PrintViewModel>(nameof(PrintViewModel));
    }
}