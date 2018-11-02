using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenbook.Sessions;
//using Greenbook.WPF.Sessions;
using Spring.Context.Attributes;

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
