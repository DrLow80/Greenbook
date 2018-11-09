using Greenbook.Data;
using Greenbook.WPF.Features.ContentItems;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.Data
{
    [Configuration]
    public class DataConfiguration : IApplicationContextAware
    {
        [Definition]
        public virtual DataViewModel DataViewModel()
        {
            return new DataViewModel(DataRepository());
        }

        [Definition]
        public virtual IDataRepository DataRepository()
        {
            return ApplicationContext.GetObject<DataContext>();
        }

        public IApplicationContext ApplicationContext { get; set; }
    }
}