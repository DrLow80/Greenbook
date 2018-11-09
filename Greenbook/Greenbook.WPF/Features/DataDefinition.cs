using Spring.Context.Attributes;

namespace Greenbook.WPF.Features
{
    [Configuration]
    public class DataDefinition
    {
        [Definition]
        public virtual DataContext DataContext()
        {
            return new DataContext();
        }
    }
}