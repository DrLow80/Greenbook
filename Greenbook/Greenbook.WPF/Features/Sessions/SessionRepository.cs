using System.Collections.Generic;
using CSharpFunctionalExtensions;
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

        public Result Insert(Session session)
        {
            return Result.Ok();
        }

        public Result Remove(Session session)
        {
            return Result.Ok();

        }
    }
}