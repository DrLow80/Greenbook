using Greenbook.Application;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.Application
{
    [Configuration]
    public class ApplicationConfiguration
    {
        [Definition]
        public virtual ApplicationViewModel ApplicationViewModel()
        {
            return new ApplicationViewModel();
        }
    }
}