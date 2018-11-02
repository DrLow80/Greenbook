using Greenbook.Domain;

namespace Greenbook.Sessions
{
    public class ViewModelLocator
    {
        public static SessionHostViewModel SessionHostViewModel => SpringContext.GetObject<SessionHostViewModel>(nameof(SessionHostViewModel));
        public static SessionListViewModel SessionListViewModel => SpringContext.GetObject<SessionListViewModel>(nameof(SessionListViewModel));
        public static SessionViewModel SessionViewModel => SpringContext.GetObject<SessionViewModel>(nameof(SessionViewModel));
    }
}