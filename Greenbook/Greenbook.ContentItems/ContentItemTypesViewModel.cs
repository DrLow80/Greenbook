using Greenbook.Domain;
using System.Collections.Generic;

namespace Greenbook.ContentItems
{
    public class ContentItemTypesViewModel : BaseListViewModel<string>
    {
        protected override IEnumerable<string> GetItems()
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