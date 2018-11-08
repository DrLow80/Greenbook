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

            _sessionRepository.Insert(Session);
        }

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(Session);
        }

        private ISessionRepository _sessionRepository;

        public SessionViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ICommand RemoveCommand=>new RelayCommand(OnRemove);

        private void OnRemove(object obj)
        {
            if (Session == null)
            {
                //what do?
            }

            _sessionRepository.Remove(Session);

            Session = null;
        }
    }
}