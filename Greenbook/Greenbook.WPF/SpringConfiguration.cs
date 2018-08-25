using Greenbook.Services;
using Greenbook.WPF.ContentItems;
using Spring.Context.Attributes;

namespace Greenbook.WPF
{
    [Configuration]
    public class SpringConfiguration
    {
        [Definition]
        public virtual ApplicationViewModel ApplicationViewModel()
        {
            return new ApplicationViewModel();
        }

        [Definition]
        public virtual ContentItemListViewModel ContentItemListViewModel()
        {
            return new ContentItemListViewModel();
        }

        [Definition]
        public virtual DataViewModel DataViewModel()
        {
            return new DataViewModel(PayloadService());
        }

        [Definition]
        public virtual IPayloadService PayloadService()
        {
            return new PayloadService();
        }

        [Definition]
        public virtual ContentItemViewModel ContentItemViewModel()
        {
            return new ContentItemViewModel();
        }
    }
}