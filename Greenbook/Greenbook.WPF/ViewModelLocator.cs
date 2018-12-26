using Greenbook.Application;
using Greenbook.Domain;
using Greenbook.Foundation.DependencyInjection;
using Greenbook.RandomTools;

namespace Greenbook.WPF
{
    public class ViewModelLocator
    {
        public static ApplicationViewModel ApplicationViewModel =>
            SpringContext.GetObject<ApplicationViewModel>(nameof(ApplicationViewModel));

        public static HomeViewModel HomeViewModel => SpringContext.GetObject<HomeViewModel>(nameof(HomeViewModel));
    }
}