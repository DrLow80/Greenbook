using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public interface ISessionRepository
    {
        IEnumerable<Session> LoadSessions();

        IEnumerable<ContentItem> LoadContentItems();

        Result Insert(Session session);

        Result Remove(Session session);
    }
}