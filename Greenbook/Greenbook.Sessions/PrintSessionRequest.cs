using CSharpFunctionalExtensions;
using Greenbook.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Greenbook.Sessions
{
    public class PrintSessionRequest
    {
        public const string ContentItemsIsNull = "FailContentItemsIsNull";
        public const string SessionHasNoEncounters = "FailSessionHasNoEncounters";
        public const string SessionIsNull = "FailSessionIsNull";

        private PrintSessionRequest(Session session, IEnumerable<ContentItem> contentItems)
        {
            Session = session;
            ContentItems = contentItems;
        }

        public IEnumerable<ContentItem> ContentItems { get; }
        public IEnumerable<Encounter> Encounters => Session.Encounters;
        public Session Session { get; }

        public static Result<PrintSessionRequest> Build(Session session, IEnumerable<ContentItem> contentItems)
        {
            if (session == null)
            {
                return Fail(SessionIsNull);
            }

            if (!session.Encounters.Any())
            {
                return Fail(SessionHasNoEncounters);
            }

            if (contentItems == null)
            {
                return Fail(ContentItemsIsNull);
            }

            PrintSessionRequest printSessionRequest = new PrintSessionRequest(session, contentItems);

            return Result.Ok(printSessionRequest);
        }

        private static Result<PrintSessionRequest> Fail(string error)
        {
            return Result.Fail<PrintSessionRequest>(error);
        }
    }
}