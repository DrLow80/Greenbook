using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions.Views
{
    public class ListSessionsViewModel : BaseListViewModel<Session>
    {
        private readonly ISessionRepository _sessionRepository;

        public ListSessionsViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        protected override IEnumerable<Session> GetItems()
        {
            return _sessionRepository.LoadSessions();
        }
    }
}