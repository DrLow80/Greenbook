using Greenbook.Services;
using Greenbook.WPF.Services;
using Spring.Context.Attributes;

namespace Greenbook.WPF
{
    [Configuration]
    public class SpringConfiguration
    {
       

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
        public virtual IDialogService DialogService()
        {
            return new DialogService();
        }
    }
}