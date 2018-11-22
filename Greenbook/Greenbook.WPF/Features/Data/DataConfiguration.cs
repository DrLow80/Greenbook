using Greenbook.Data;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.Data
{
    [Configuration]
    public class DataConfiguration : IApplicationContextAware
    {
        public IApplicationContext ApplicationContext { get; set; }

        [Definition]
        public virtual DataViewModel DataViewModel()
        {
            return new DataViewModel(DataRepository());
        }

        [Definition]
        public virtual IDataRepository DataRepository()
        {
            return ApplicationContext.GetObject<ProjectRepository>();
        }
    }
}