using Greenbook.RandomTools;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.RandomTools
{
    [Configuration]
    public class RandomToolsConfiguration : IApplicationContextAware
    {
        public IApplicationContext ApplicationContext { get; set; }

        [Definition]
        public virtual HomeViewModel HomeViewModel()
        {
            return new HomeViewModel(RandomToolsRepository());
        }

        [Definition]
        public virtual IRandomToolsRepository RandomToolsRepository()
        {
            return ApplicationContext.GetObject<ProjectRepository>();
        }

        [Definition]
        public virtual TestOneViewModel TestOneViewModel()
        {
            return new TestOneViewModel();
        }

        [Definition]
        public virtual TestTwoViewModel TestTwoViewModel()
        {
            return new TestTwoViewModel();
        }
    }
}