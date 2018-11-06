using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class SessionListViewModel : BaseListViewModel<Session>
    {
        private readonly ISessionRepository _sessionRepository;

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