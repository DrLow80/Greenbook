using Greenbook.Domain;
using Greenbook.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Greenbook.Sessions
{
    public class SessionListViewModel : BaseListViewModel<Session>
    {
        private ISessionRepository _sessionRepository;

        public SessionListViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        protected override IEnumerable<Session> GetItems()
        {
            return _sessionRepository.LoadSessions();
        }
    }
}