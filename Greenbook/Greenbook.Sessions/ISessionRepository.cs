using System.Collections.Generic;
using System.Windows.Documents;
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
        Result<FlowDocument> BuildPrintDocument(Session session);
    }
}