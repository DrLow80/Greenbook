using Spring.Context.Attributes;

namespace Greenbook.WPF.Features
{
    [Configuration]
    public class ProjectRepositoryConfiguration
    {
        [Definition]
        public virtual ProjectRepository DataContext()
        {
            return new ProjectRepository();
        }
    }
}