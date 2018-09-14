using System.Collections.Concurrent;
using System.Collections.Generic;
using Greenbook.Entities;
using Greenbook.WPF.View.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.Entities.AhoCorasick;
using Greenbook.Entities.AhoCorasick.Iterators;
using Greenbook.WPF.Extensions;

namespace Greenbook.WPF.Sessions
{
    public class SessionViewModel : BaseViewModel
    {
        public Session Session { get; set; }

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand RemoveCommand => new RelayCommand<Encounter>(OnRemove);

        public ICommand AddCommand => new RelayCommand(OnAdd);

        private void OnCreate(object obj)
        {
            Session = new Session();
        }

        public void Load()
        {
            Encounters.ClearAndLoad(Session.Encounters);
        }

        private void OnAdd(object obj)
        {
            var encounter = new Encounter();

            Session.Encounters.Add(encounter);

            Encounters.Add(encounter);
        }

        private void OnRemove(Encounter obj)
        {
            if (Encounters.Contains(obj)) Encounters.Remove(obj);

            Session.Encounters.Remove(obj);
        }

        public ICommand ScanCommand => new RelayCommand<IEnumerable<ContentItem>>(OnScan);

        private void OnScan(IEnumerable<ContentItem> obj)
        {
            Trie trie = new Trie(obj.Select(x => x.Name).ToArray());

            SessionTrieIterator sessionTrieIterator = new SessionTrieIterator(Session, obj);

            trie.Iterate(sessionTrieIterator);
            
            ContentItems.ClearAndLoad(sessionTrieIterator);
        }

        public ObservableCollection<ContentItem> ContentItems { get; private set; } = new ObservableCollection<ContentItem>();
    }
}