using System.Collections.Generic;
using System.Windows.Documents;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class PrintSessionFactory
    {
        public static FlowDocument Print(PrintSessionRequest printSessionRequest)
        {
            FlowDocument flowDocument = new FlowDocument();

            IEnumerable<Block> blocks = BuildBlocks(printSessionRequest);

            flowDocument.Blocks.AddRange(blocks);

            return flowDocument;
        }

        private static IEnumerable<Block> BuildBlocks(PrintSessionRequest printSessionRequest)
        {
            yield return BuildSessionBlock(printSessionRequest.Session);

            foreach (var encounter in printSessionRequest.Encounters)
            {
                yield return BuildEncounterBlock(encounter);
            }

            foreach (var contentItem in printSessionRequest.ContentItems)
            {
                yield return BuildContentItemBlock(contentItem);
            }
        }

        private static Block BuildContentItemBlock(ContentItem contentItem)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(contentItem.Name);

            paragraph.Inlines.Add(run);

            return paragraph;
        }

        private static Block BuildEncounterBlock(Encounter encounter)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(encounter.Name);

            paragraph.Inlines.Add(run);

            paragraph.Inlines.Add(new LineBreak());

            run = new Run(encounter.Description);

            paragraph.Inlines.Add(run);

            return paragraph;
        }

        private static Block BuildSessionBlock(Session session)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(session.Name);

            paragraph.Inlines.Add(run);

            return paragraph;
        }
    }
}