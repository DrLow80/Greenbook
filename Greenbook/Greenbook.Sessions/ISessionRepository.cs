using System.Collections.Generic;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public interface ISessionRepository
    {
        IEnumerable<Session> LoadSessions();
        IEnumerable<ContentItem> LoadContentItems();
    }
}