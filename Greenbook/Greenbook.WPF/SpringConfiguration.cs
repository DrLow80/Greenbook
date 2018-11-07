using Greenbook.Services;
using Spring.Context.Attributes;

namespace Greenbook.WPF
{
    [Configuration]
    public class SpringConfiguration
    {
        [Definition]
        public virtual DataViewModel DataViewModel()
        {
            //return new DataViewModel(PayloadService());

            return new DataViewModel();
        }

        [Definition]
        public virtual IPayloadService PayloadService()
        {
            return new PayloadService();
        }
    }
}