using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenbook.ContentItemTypes;
using Spring.Context;
using Spring.Context.Attributes;

namespace Greenbook.WPF.Features.ContentItemTypeListViews
{
    [Configuration]
    public class ContentItemTypeListViewConfiguration: IApplicationContextAware
    {
        [Definition]
        public virtual ContentItemsTypesHostViewModel ContentItemsTypesHostViewModel()
        {
            return new ContentItemsTypesHostViewModel();
        }

        [Definition]
        public virtual ContentItemTypeListViewModel ContentItemTypeListViewModel()
        {
            return new ContentItemTypeListViewModel(ContentItemTypesRepository());
        }

        [Definition]
        public virtual IContentItemTypesRepository ContentItemTypesRepository()
        {
            return ApplicationContext.GetObject<DataContext>();
        }

        public IApplicationContext ApplicationContext { get; set; }
    }
}
