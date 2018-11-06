using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class ContentItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();
        public ObservableCollection<ContentItem> ScannedContentItems { get; } = new ObservableCollection<ContentItem>();

        public void Load()
        {
            ContentItems.Clear();

            foreach (var contentItem in _sessionRepository.LoadContentItems().OrderBy(x => x.Name))
            {
                ContentItems.Add(contentItem);
            }

            ContentItemsByTypeGroups.Clear();

            foreach (var type in ContentItems.GroupBy(x => x.ContentType).OrderBy(x => x.Key))
            {
                ContentItemsByTypeGroup contentItemsByTypeGroup = new ContentItemsByTypeGroup(type.Key, type.OrderBy(x => x.Name));

                ContentItemsByTypeGroups.Add(contentItemsByTypeGroup);
            }
        }

        private ISessionRepository _sessionRepository;

        public ContentItemsViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ObservableCollection<ContentItemsByTypeGroup> ContentItemsByTypeGroups { get; } = new ObservableCollection<ContentItemsByTypeGroup>();
    }
}
