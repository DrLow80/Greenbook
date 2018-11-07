using Greenbook.Sessions;
using Spring.Context.Attributes;
//using Greenbook.WPF.Sessions;

namespace Greenbook.WPF.Features.Sessions
{
    [Configuration]
    public class SessionConfiguration
    {
        [Definition]
        public virtual SessionViewModel SessionViewModel()
        {
            return new SessionViewModel();
        }

        [Definition]
        public virtual SessionListViewModel SessionListViewModel()
        {
            return new SessionListViewModel(SessionRepository());
        }

        [Definition]
        public virtual SessionHostViewModel SessionHostViewModel()
        {
            return new SessionHostViewModel();
        }

        [Definition]
        public virtual ISessionRepository SessionRepository()
        {
            return new SessionRepository();
        }

        [Definition]
        public virtual ContentItemsViewModel ContentItemsViewModel()
        {
            return new ContentItemsViewModel(SessionRepository());
        }

        [Definition]
        public virtual PrintViewModel PrintViewModel()
        {
            return new PrintViewModel(SessionRepository());
        }
    }
}