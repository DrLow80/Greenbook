using Greenbook.Domain;
using System.Collections.Generic;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public class ContentItemTypesViewModel : BaseListViewModel<ContentItemType>
    {
        protected override IEnumerable<ContentItemType> GetItems()
        {
            return _contentItemsRepository.LoadContentItemTypes();
        }

        private IContentItemsRepository _contentItemsRepository;

        public ContentItemTypesViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }
    }
}