using System.Windows.Input;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class SessionViewModel : BaseViewModel
    {
        public Session Session { get; set; }

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public EncountersViewModel EncountersViewModel { get; private set; }

        private void OnCreate(object obj)
        {
            Session = new Session();
        }

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(Session);
        }
    }
}