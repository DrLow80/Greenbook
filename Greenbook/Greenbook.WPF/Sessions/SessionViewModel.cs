using Greenbook.Entities;
using Greenbook.Entities.AhoCorasick;
using Greenbook.Entities.AhoCorasick.Iterators;
using Greenbook.WPF.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.Domain;

namespace Greenbook.WPF.Sessions
{
    public class SessionViewModel : BaseViewModel
    {
        public Session Session { get; set; }

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand RemoveCommand => new RelayCommand<Encounter>(OnRemove);

        public ICommand AddCommand => new RelayCommand(OnAdd);

        public ICommand ScanCommand => new RelayCommand<IEnumerable<ContentItem>>(OnScan);

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();

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

        private void OnScan(IEnumerable<ContentItem> obj)
        {
            var trie = new Trie(obj.Select(x => x.Name).ToArray());

            var sessionTrieIterator = new SessionTrieIterator(Session, obj);

            trie.Iterate(sessionTrieIterator);

            ContentItems.ClearAndLoad(sessionTrieIterator);
        }
    }
}