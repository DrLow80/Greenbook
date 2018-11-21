using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItemTypes
{
    public class ContentItemTypeListViewModel : BaseListViewModel<ContentItemType>
    {
        private readonly IContentItemTypesRepository _contentItemTypesRepository;

        public ContentItemTypeListViewModel(IContentItemTypesRepository contentItemTypesRepository)
        {
            _contentItemTypesRepository = contentItemTypesRepository;
        }

        protected override IEnumerable<ContentItemType> GetItems()
        {
            return _contentItemTypesRepository.LoadContentItemTypes();
        }
    }
}