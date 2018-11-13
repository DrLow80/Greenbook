using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItems.Views
{
    public class ListViewModel : BaseListViewModel<ContentItem>
    {
        private readonly IContentItemsRepository _contentItemsRepository;

        public ListViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }

        protected override IEnumerable<ContentItem> GetItems()
        {
            return _contentItemsRepository.LoadContentItems();
        }
    }
}