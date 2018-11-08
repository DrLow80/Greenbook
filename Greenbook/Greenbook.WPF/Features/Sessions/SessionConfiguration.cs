using Greenbook.Sessions;
using Greenbook.WPF.Features.ContentItems;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.Sessions
{
    [Configuration]
    public class SessionConfiguration: IApplicationContextAware
    {
        [Definition]
        public virtual SessionViewModel SessionViewModel()
        {
            return new SessionViewModel(SessionRepository());
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
            return ApplicationContext.GetObject<TestDataRepo>();
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

        public IApplicationContext ApplicationContext { get; set; }
    }
}