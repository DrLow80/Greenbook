using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItemTypes
{
public    class ContentItemTypeListViewModel:BaseListViewModel<ContentItemType>
    {
        protected override IEnumerable<ContentItemType> GetItems()
        {
            return _contentItemTypesRepository.LoadContentItemTypes();
        }

        private IContentItemTypesRepository _contentItemTypesRepository;

        public ContentItemTypeListViewModel(IContentItemTypesRepository contentItemTypesRepository)
        {
            _contentItemTypesRepository = contentItemTypesRepository;
        }
    }
}
