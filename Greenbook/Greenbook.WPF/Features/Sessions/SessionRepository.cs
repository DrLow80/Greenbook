using System.Collections.Generic;
using Greenbook.Entities;
using Greenbook.Sessions;

namespace Greenbook.WPF.Features.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        public IEnumerable<Session> LoadSessions()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomSession);
        }

        public IEnumerable<ContentItem> LoadContentItems()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomContentItem);
        }
    }
}