using Greenbook.RandomTools;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.RandomTools
{
    [Configuration]
    public class RandomToolsConfiguration
    {
        [Definition]
        public virtual HomeViewModel HomeViewModel()
        {
            return new HomeViewModel(RandomToolsRepository());
        }

        [Definition]
        public virtual IRandomToolsRepository RandomToolsRepository()
        {
            return new RandomToolsRepository();
        }
    }
}