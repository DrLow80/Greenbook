using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public class ContentItemListViewModel : BaseListViewModel<ContentItem>
    {
        private readonly IContentItemsRepository _contentItemsRepository;

        public ContentItemListViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }

        protected override IEnumerable<ContentItem> GetItems()
        {
            return _contentItemsRepository.LoadContentItems();
        }
    }
}