using Greenbook.Entities;
using Greenbook.WPF.View.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
            Encounters.Clear();

            foreach (var encounter in Session.Encounters) Encounters.Add(encounter);
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
    }
}