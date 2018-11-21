using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.AhoCorasickTrie;
using Greenbook.Domain;
using Greenbook.Entities;
using Greenbook.Extensions;

namespace Greenbook.Sessions
{
    public class PrintViewModel : BaseViewModel
    {
        private readonly ISessionRepository _sessionRepository;

        public PrintViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();
        public ICommand PrintCommand => new RelayCommand<Session>(OnPrint);
        public Session Session { get; set; }

        private void OnPrint(Session obj)
        {
            Session = obj;

            var contentItems = _sessionRepository.LoadContentItems().ToArray();

            var trie = new Trie(contentItems.Select(x => x.Name).ToArray());

            var sessionTrieIterator = new SessionTrieIterator(Session, contentItems);

            trie.Iterate(sessionTrieIterator);

            ContentItems.ClearAndLoad(sessionTrieIterator);
        }
    }
}