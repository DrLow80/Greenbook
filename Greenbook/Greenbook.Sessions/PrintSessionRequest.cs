using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class PrintSessionRequest
    {
        public Session Session { get; }

        public IEnumerable<ContentItem> ContentItems { get; }

        public IEnumerable<Encounter> Encounters => Session.Encounters;

        private PrintSessionRequest(Session session, IEnumerable<ContentItem> contentItems)
        {
            Session = session;
            ContentItems = contentItems;
        }

        public const string FailSessionIsNull = "FailSessionIsNull";
        public const string FailSessionHasNoEncounters = "FailSessionHasNoEncounters";
        public const string FailContentItemsIsNull = "FailContentItemsIsNull";

        public static Result<PrintSessionRequest> Build(Session session, IEnumerable<ContentItem> contentItems)
        {
            if (session == null)
            {
                return Fail(FailSessionIsNull);
            }

            if (!session.Encounters.Any())
            {
                return Fail(FailSessionHasNoEncounters);
            }

            if (contentItems == null)
            {
                return Fail(FailContentItemsIsNull);
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