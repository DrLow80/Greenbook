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

        //[Definition]
        //public virtual SessionPrintViewModel SessionPrintViewModel()
        //{
        //    return new SessionPrintViewModel();
        //}

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
    }
}