using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public class ContentItemListViewModel:BaseListViewModel<ContentItem>
    {
        protected override IEnumerable<ContentItem> GetItems()
        {
            return _contentItemsRepository.LoadContentItems();
        }

        private IContentItemsRepository _contentItemsRepository;

        public ContentItemListViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }
    }
}
