using Greenbook.Application;
using Greenbook.Domain;
using Greenbook.RandomTools;

namespace Greenbook.WPF
{
    public class ViewModelLocator
    {
        public static ApplicationViewModel ApplicationViewModel =>
            SpringContext.GetObject<ApplicationViewModel>(nameof(ApplicationViewModel));

        public static DataViewModel DataViewModel => SpringContext.GetObject<DataViewModel>(nameof(DataViewModel));

        public static HomeViewModel HomeViewModel => SpringContext.GetObject<HomeViewModel>(nameof(HomeViewModel));
    }
}