using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.AhoCorasickTrie;
using Greenbook.Domain;
using Greenbook.Entities;
using Greenbook.Extensions;

namespace Greenbook.Sessions
{
    public class ContentItemsViewModel : BaseViewModel
    {
        private readonly ISessionRepository _sessionRepository;

        public ContentItemsViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();

        public ObservableCollection<ContentItemsByTypeGroup> ContentItemsByTypeGroups { get; } =
            new ObservableCollection<ContentItemsByTypeGroup>();

        public ObservableCollection<ContentItem> ScannedContentItems { get; } = new ObservableCollection<ContentItem>();

        public void Load()
        {
            ContentItems.ClearAndLoad(_sessionRepository.LoadContentItems().OrderBy(x => x.Name));

            ContentItemsByTypeGroups.Clear();

            foreach (var type in ContentItems.GroupBy(x => x.ContentType).OrderBy(x => x.Key))
            {
                var contentItemsByTypeGroup = new ContentItemsByTypeGroup(type.Key, type.OrderBy(x => x.Name));

                ContentItemsByTypeGroups.Add(contentItemsByTypeGroup);
            }
        }

        public ICommand ChangeViewCommand => new RelayCommand<ViewType>(OnChangeView);

        private void OnChangeView(ViewType obj)
        {
            ViewType = obj;
        }

        public ViewType ViewType { get; private set; } = ViewType.Referenced;

        public ICommand ScanCommand=>new RelayCommand<Session>(OnScan);

        private void OnScan(Session obj)
        {
            if (!obj.Encounters.Any())
            {
                ScannedContentItems.Clear();

                return;
            }

            Trie trie = new Trie(ContentItems.Select(x=>x.Name).ToArray());

            SessionTrieIterator sessionTrieIterator = new SessionTrieIterator(obj, ContentItems);

            trie.Iterate(sessionTrieIterator);

            ScannedContentItems.ClearAndLoad(sessionTrieIterator);
        }
    }
}