using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
