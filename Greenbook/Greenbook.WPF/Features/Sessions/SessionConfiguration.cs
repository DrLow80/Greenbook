using Greenbook.Sessions;
using Greenbook.Sessions.Views;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.Sessions
{
    [Configuration]
    public class SessionConfiguration : IApplicationContextAware
    {
        public IApplicationContext ApplicationContext { get; set; }

        [Definition]
        public virtual SessionViewModel SessionViewModel()
        {
            return new SessionViewModel(SessionRepository());
        }

        [Definition]
        public virtual ListSessionsViewModel ListSessionsViewModel()
        {
            return new ListSessionsViewModel(SessionRepository());
        }

        [Definition]
        public virtual HostSessionViewModel HostSessionViewModel()
        {
            return new HostSessionViewModel();
        }

        [Definition]
        public virtual ISessionRepository SessionRepository()
        {
            return ApplicationContext.GetObject<ProjectRepository>();
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