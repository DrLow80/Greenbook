using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Greenbook.Domain;
using Greenbook.Entities;
using Greenbook.Entities.AhoCorasick;
using Greenbook.Entities.AhoCorasick.Iterators;

namespace Greenbook.Sessions
{
    public class SessionViewModel : BaseViewModel
    {
        public Session Session { get; set; }

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        private void OnCreate(object obj)
        {
            Session = new Session();
        }

        public EncountersViewModel EncountersViewModel { get; private set; }

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(Session);
        }
    }
}
